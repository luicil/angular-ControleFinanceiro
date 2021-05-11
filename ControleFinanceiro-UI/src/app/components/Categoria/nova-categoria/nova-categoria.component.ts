import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Tipo } from 'src/app/models/Tipo';
import { TiposService } from 'src/app/services/tipos.service';

@Component({
  selector: 'app-nova-categoria',
  templateUrl: './nova-categoria.component.html',
  styleUrls: ['./nova-categoria.component.css']
})
export class NovaCategoriaComponent implements OnInit {

  formulario: any;
  tipos: Tipo[];

  constructor( private tiposService: TiposService) { }

  ngOnInit(): void {
    this.tiposService.pegarTodos().subscribe(res =>{
      this.tipos = res;

      this.formulario = new FormGroup({
        nome: new FormControl(null),
        icone: new FormControl(null),
        tipoid: new FormControl(null),
      });
    
    })
  }

  get propriedade(){
    return this.formulario.controls;
  }

}
