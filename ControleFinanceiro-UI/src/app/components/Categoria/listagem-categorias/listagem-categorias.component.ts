import { Component, Inject, OnInit } from '@angular/core';
import { CategoriasService } from '../../../services/categorias.service';
import { MatTableDataSource}  from '@angular/material/table';
import { MatDialog, MAT_DIALOG_DATA  } from '@angular/material/dialog';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';

@Component({
  selector: 'app-listagem-categorias',
  templateUrl: './listagem-categorias.component.html',
  styleUrls: ['./listagem-categorias.component.css']
})
export class ListagemCategoriasComponent implements OnInit {

  Categorias = new MatTableDataSource<any>();
  displayedcolumns: string[];
  autoCompleteInput = new FormControl();
  optCategorias : string[] = [];
  nomesCategorias : Observable<string[]>;


  constructor(private categoriasService : CategoriasService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.categoriasService.pegarTodos().subscribe(res =>{
      this.Categorias.data = res;

      res.forEach(cat => {
        this.optCategorias.push(cat.nome);
      });
    })
    
    this.displayedcolumns = this.ExibirColunas();

    this.nomesCategorias = this.autoCompleteInput.valueChanges.pipe(startWith(``), map(nome => this.FiltrarNomes(nome)));
    
  }

  ExibirColunas(): string[] {
    return ['nome', 'icone', 'tipo', 'acoes']
  }

  AbrirDialog(categoriaID, nome): void {

    this.dialog.open(DialogExclusaoCategoriaComponent,{
      data: {
        categoriaID: categoriaID,
        nome: nome
      }
    }).afterClosed().subscribe(res =>{
      if(res){
        debugger;
        this.categoriasService.pegarTodos().subscribe(dados =>{
          this.Categorias.data = dados;
          this.displayedcolumns = this.ExibirColunas();
        });
      }
    });
    
  }
 
  FiltrarNomes(nome : string) : string[] {
    if(nome.trim().length >= 4){
      this.categoriasService.filtrarCategorias(nome.toLowerCase()).subscribe(res =>{
        this.Categorias.data = res;
      });
    } else {
      if(nome === ""){
        this.categoriasService.pegarTodos().subscribe(res =>{
          this.Categorias.data = res;
        });
      }
    }
    return this.optCategorias.filter(cat =>{
      cat.toLowerCase().includes(nome.toLowerCase());
    });
  }

}
@Component({
  selector: 'app-dialog-exclusao-categorias',
  templateUrl: 'dialog-exclusao-categorias.html'
})

export class DialogExclusaoCategoriaComponent{
 constructor(@Inject(MAT_DIALOG_DATA) public dados: any,
 private categoriasService: CategoriasService) { }

  ExcluirCategoria(categoriaID): void {
    console.log("Categoria: "+ categoriaID);
    this.categoriasService.excluirCategoria(categoriaID).subscribe(res =>{
      console.log("Res: " + res);
    })
  }

}

