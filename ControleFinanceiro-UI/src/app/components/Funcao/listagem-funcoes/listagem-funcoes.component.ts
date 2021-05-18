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
  autoCompleteInput = new FormControl();
  optFuncoes : string[] = [];
  nomesFuncoes : Observable<string[]>;

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  constructor(private funcoesService: FuncoesService) { }

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

    //this.nomesFuncoes = this.autoCompleteInput.valueChanges.pipe(startWith(''), map(nome => this.FiltrarNomes(nome)));

  }

  ExibirColunas(): string[] {
    return ['nome', 'descricao', 'acoes'];
  }


}
