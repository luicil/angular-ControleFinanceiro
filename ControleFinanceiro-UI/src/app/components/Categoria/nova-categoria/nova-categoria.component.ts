import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Tipo } from 'src/app/models/Tipo';
import { CategoriasService } from 'src/app/services/categorias.service';
import { TiposService } from 'src/app/services/tipos.service';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-nova-categoria',
  templateUrl: './nova-categoria.component.html',
  styleUrls: ['../listagem-categorias/listagem-categorias.component.css']
})
export class NovaCategoriaComponent implements OnInit {

  formulario: any;
  tipos: Tipo[];
  erros: string[];

  constructor( private tiposService: TiposService, 
    private categoriasSerivce: CategoriasService,
    private router: Router,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.tiposService.pegarTodos().subscribe((res) =>{
      this.erros = [];
      this.tipos = res;

      this.formulario = new FormGroup({
        nome: new FormControl(null, [Validators.required, Validators.maxLength(50)]),
        icone: new FormControl(null, [Validators.required, Validators.maxLength(15)]),
        tipoID: new FormControl(null, [Validators.required]),
      });
    })
  }

  get propriedade(){
    return this.formulario.controls;
  }

  EnviarFormulario(): void {
    this.erros = [];
    const categoria = this.formulario.value;
    this.categoriasSerivce.novaCategoria(categoria).subscribe(res =>{
      this.voltarListagem();
      this.snackBar.open(res.mensagem,null,{
        duration: 2000,
        horizontalPosition: "right",
        verticalPosition: "top"
      });
    }, 
    (err) =>{
      if(err.status == 400){
        for(const campo in err.error.errors){
          if(err.error.errors.hasOwnProperty(campo)){
            this.erros.push(err.error.errors[campo]);
          }
        }
      }
    });
  }

  voltarListagem(): void {
    this.router.navigate(["categorias/listagemcategorias"]);
  }

}
