import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Tipo } from 'src/app/models/Tipo';
import { CategoriasService } from 'src/app/services/categorias.service';
import { TiposService } from 'src/app/services/tipos.service';

@Component({
  selector: 'app-nova-categoria',
  templateUrl: './nova-categoria.component.html',
  styleUrls: ['../listagem-categorias/listagem-categorias.component.css']
})
export class NovaCategoriaComponent implements OnInit {

  formulario: any;
  tipos: Tipo[];

  constructor( private tiposService: TiposService, 
    private categoriasSerivce: CategoriasService,
    private router: Router) { }

  ngOnInit(): void {
    this.tiposService.pegarTodos().subscribe((res) =>{
      this.tipos = res;

      this.formulario = new FormGroup({
        nome: new FormControl(null),
        icone: new FormControl(null),
        tipoID: new FormControl(null),
      });
    
    })
  }

  get propriedade(){
    return this.formulario.controls;
  }

  EnviarFormulario(): void {
    const categoria = this.formulario.value;
    this.categoriasSerivce.novaCategoria(categoria).subscribe(res =>{
      this.router.navigate(["categorias/listagemcategorias"]);
    })
  }

  voltarListagem(): void {
    this.router.navigate(["categorias/listagemcategorias"]);
  }

}
