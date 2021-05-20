import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FuncoesService } from '../../../services/funcoes.service';
import { MatTableDataSource}  from '@angular/material/table';
import { MatDialog, MAT_DIALOG_DATA  } from '@angular/material/dialog';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';
import { MatPaginator } from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatSnackBar} from '@angular/material/snack-bar';


@Component({
  selector: 'app-listagem-funcoes',
  templateUrl: './listagem-funcoes.component.html',
  styleUrls: ['./listagem-funcoes.component.css']
})
export class ListagemFuncoesComponent implements OnInit {

  funcoes = new MatTableDataSource<any>();
  displayedcolumns: string[];
  autocompleteInput = new FormControl();
  optFuncoes : string[] = [];
  nomesFuncoes : Observable<string[]>;

  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;

  constructor(private funcoesService: FuncoesService, private dialog: MatDialog) { }

  ngOnInit(): void {

    this.funcoesService.pegarTodos().subscribe(res =>{

      res.forEach(func => {
        this.optFuncoes.push(func.name);
      });

      this.funcoes.data = res;
      this.funcoes.paginator = this.paginator;
      this.funcoes.sort = this.sort;

    });

    this.displayedcolumns = this.ExibirColunas();

    this.nomesFuncoes = this.autocompleteInput.valueChanges.pipe(startWith(""), map(nome => this.FiltrarNomes(nome)));

  }

  ExibirColunas(): string[] {
    return ['nome', 'descricao', 'acoes'];
  }

  AbrirDialog(funcaoID, name): void {
    this.dialog.open(DialogExclusaoFuncaoComponent,{
      data: {
        id: funcaoID,
        name: name
      }
    }).afterClosed().subscribe(res =>{
      if(res){
        this.funcoesService.pegarTodos().subscribe(dados =>{
          this.funcoes.data = dados;
          this.displayedcolumns = this.ExibirColunas();
        });
      }
    });
    
  }

  FiltrarNomes(nome : string) : string[] {
    
    if(nome.trim().length >= 4){
      this.funcoesService.filtrarFuncoes(nome.toLowerCase()).subscribe(res =>{
        this.funcoes.data = res;
      });
    } else {
      if(nome === ""){
        this.funcoesService.pegarTodos().subscribe(res =>{
          this.funcoes.data = res;
        });
      }
    }
    return this.optFuncoes.filter(func =>{
      func.toLowerCase().includes(nome.toLowerCase());
    });
  }  

}

@Component({
  selector: 'app-dialog-exclusao-funcao',
  templateUrl: 'dialog-exclusao-funcao.html'
})

export class DialogExclusaoFuncaoComponent{
 constructor(@Inject(MAT_DIALOG_DATA) public dados: any,
 private funcoesService: FuncoesService,
 private snackBar : MatSnackBar) { }

  ExcluirFuncao(funcaoID): void {
    this.funcoesService.excluirFuncao(funcaoID).subscribe(res =>{
      this.snackBar.open(res.mensagem,null,{
        duration: 2000,
        horizontalPosition: "right",
        verticalPosition: "top"
      });
    });
  }

}