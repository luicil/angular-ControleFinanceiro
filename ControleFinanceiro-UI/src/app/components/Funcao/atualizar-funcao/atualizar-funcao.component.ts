import { Component, OnInit } from '@angular/core';
import { stringify } from '@angular/compiler/src/util';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';

import {MatSnackBar} from '@angular/material/snack-bar';
import { FuncoesService } from 'src/app/services/funcoes.service';


@Component({
  selector: 'app-atualizar-funcao',
  templateUrl: './atualizar-funcao.component.html',
  styleUrls: ['./atualizar-funcao.component.css']
})
export class AtualizarFuncaoComponent implements OnInit {

  id: string;
  name: string;
  descricao: string;
  formulario: any;
  erros: string[];

  constructor(private router: Router,
    private route: ActivatedRoute,
    private funcoesService: FuncoesService,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.erros = [];
    this.id = this.route.snapshot.params.id;
    this.funcoesService.pegarFuncaoID(this.id).subscribe(res =>{
      this.name = res.name;
      this.descricao = res.descricao;
      this.formulario = new FormGroup({
        id: new FormControl(res.id),
        name: new FormControl(res.name, [Validators.required, Validators.maxLength(50)]),
        descricao: new FormControl(res.name, [Validators.required, Validators.maxLength(50)]),        
      });      
    });
  }

  get propriedade(){
    return this.formulario.controls;
  }

  voltarListagem(): void {
    this.router.navigate(["funcoes/listagemfuncoes"]);
  }

  EnviarFormulario(): void {
    this.erros = [];
    const funcao = this.formulario.value;
    this.funcoesService.atualizarFuncao(this.id, funcao).subscribe(res =>{
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

}

