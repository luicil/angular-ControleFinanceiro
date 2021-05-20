import { Component, OnInit } from '@angular/core';

import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UsuariosService } from '../../../../services/usuarios.service';

@Component({
  selector: 'app-registrar-usuario',
  templateUrl: './registrar-usuario.component.html',
  styleUrls: ['./registrar-usuario.component.css']
})
export class RegistrarUsuarioComponent implements OnInit {

  formulario: any;
  foto: File = null;
  erros: string[];

  constructor(
    private usuariosService: UsuariosService,
    private router: Router,
    private snackBar: MatSnackBar    

  ) { }

  ngOnInit(): void {
    this.erros=[];
    this.formulario = new FormGroup({
      nomeusuario: new FormControl(null, [Validators.required, Validators.minLength(6), Validators.maxLength(50)]),
      cpf: new FormControl(null, [Validators.required, Validators.minLength(1), Validators.maxLength(20)]),
      profissao: new FormControl(null, [Validators.required, Validators.minLength(6), Validators.maxLength(30)]),
      foto: new FormControl(null, [Validators.required]),
      email: new FormControl(null, [Validators.required, Validators.email, Validators.minLength(10), Validators.maxLength(30)]),
      senha: new FormControl(null, [Validators.required, Validators.minLength(6), Validators.maxLength(50)]),
    });
  }

  get propriedade(){
    return this.formulario.controls;
  }

}
