import { Component, OnInit } from '@angular/core';

import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Funcao } from 'src/app/models/Funcao';
import { FuncoesService } from 'src/app/services/funcoes.service';
import {MatSnackBar} from '@angular/material/snack-bar';


@Component({
  selector: 'app-nova-funcao',
  templateUrl: './nova-funcao.component.html',
  styleUrls: ['../listagem-funcoes/listagem-funcoes.component.css']
})
export class NovaFuncaoComponent implements OnInit {

  formulario: any;
  erros: string[];

  constructor(
    private funcoesService: FuncoesService,
    private router: Router,
    private snackBar: MatSnackBar    
  ) { }

  ngOnInit(): void {

    this.erros = [];
    this.formulario = new FormGroup({
      name: new FormControl(null, [Validators.required, Validators.maxLength(50)]),
      descricao: new FormControl(null, [Validators.required, Validators.maxLength(50)]),
    });

  }

  get propriedade(){
    return this.formulario.controls;
  }

  EnviarFormulario(): void {
    this.erros = [];
    const funcao = this.formulario.value;
    this.funcoesService.novaFuncao(funcao).subscribe(res =>{
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
    this.router.navigate(["funcoes/listagemfuncoes"]);
  }

}
