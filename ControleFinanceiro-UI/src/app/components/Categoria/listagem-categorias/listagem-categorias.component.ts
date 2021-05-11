import { Component, OnInit } from '@angular/core';
import { CategoriasService } from '../../../services/categorias.service';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
@Component({
  selector: 'app-listagem-categorias',
  templateUrl: './listagem-categorias.component.html',
  styleUrls: ['./listagem-categorias.component.css']
})
export class ListagemCategoriasComponent implements OnInit {

  Categorias = new MatTableDataSource<any>();
  displayedcolumns: string[];

  constructor(private categoriasService : CategoriasService) { }

  ngOnInit(): void {
    this.categoriasService.pegarTodos().subscribe(res =>{
      this.Categorias.data = res;
    })

    this.displayedcolumns = this.ExibirColunas();

  }

  ExibirColunas(): string[] {
    return ['nome', 'icone', 'tipo', 'acoes']
  }

}
