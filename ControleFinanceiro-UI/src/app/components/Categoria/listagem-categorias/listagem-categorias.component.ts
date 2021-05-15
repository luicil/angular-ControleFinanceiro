import { Component, Inject, OnInit } from '@angular/core';
import { CategoriasService } from '../../../services/categorias.service';
import { MatTableDataSource}  from '@angular/material/table';
import { MatDialog, MAT_DIALOG_DATA  } from '@angular/material/dialog';
@Component({
  selector: 'app-listagem-categorias',
  templateUrl: './listagem-categorias.component.html',
  styleUrls: ['./listagem-categorias.component.css']
})
export class ListagemCategoriasComponent implements OnInit {

  Categorias = new MatTableDataSource<any>();
  displayedcolumns: string[];

  constructor(private categoriasService : CategoriasService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.categoriasService.pegarTodos().subscribe(res =>{
      this.Categorias.data = res;
    })
    
    this.displayedcolumns = this.ExibirColunas();
    
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

