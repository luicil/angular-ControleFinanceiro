import { stringify } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Categoria } from 'src/app/models/Categoria';
import { Tipo } from 'src/app/models/Tipo';
import { CategoriasService } from 'src/app/services/categorias.service';
import { TiposService } from 'src/app/services/tipos.service';

@Component({
  selector: 'app-atualizar-categoria',
  templateUrl: './atualizar-categoria.component.html',
  styleUrls: ['../listagem-categorias/listagem-categorias.component.css']
})
export class AtualizarCategoriaComponent implements OnInit {

  categoriaID: number;
  nomeCategoria: string;
  categoria: Observable<Categoria>;
  tipos: Tipo[];
  formulario: any;

  constructor(private router: Router,
    private route: ActivatedRoute,
    private tiposService: TiposService, 
    private categoriasSerivce: CategoriasService) { }

  ngOnInit(): void {
    
    this.categoriaID = this.route.snapshot.params.id;
    this.tiposService.pegarTodos().subscribe(res =>{
      this.tipos = res;
    });

    this.categoriasSerivce.pegarcategoriaID(this.categoriaID).subscribe(res =>{
      this.nomeCategoria = res.nome;
      this.formulario = new FormGroup({
        categoriaid: new FormControl(res.categoriaID),
        nome: new FormControl(res.nome),
        icone: new FormControl(res.icone),
        tipoID: new FormControl(res.tipoID),
      });      
    });
  }

  get propriedade(){
    return this.formulario.controls;
  }

  voltarListagem(): void {
    this.router.navigate(["categorias/listagemcategorias"]);
  }

  EnviarFormulario(): void {
    const categoria = this.formulario.value;
    this.categoriasSerivce.atualizarCategoria(this.categoriaID, categoria).subscribe(res =>{
      this.voltarListagem();
    });
  }
}