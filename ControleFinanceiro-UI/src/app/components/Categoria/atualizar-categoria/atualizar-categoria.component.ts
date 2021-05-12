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

  categoria: Observable<Categoria>;
  tipos: Tipo[];
  formulario: any;

  constructor(private router: Router,
    private route: ActivatedRoute,
    private tiposService: TiposService, 
    private categoriasSerivce: CategoriasService) { }

  ngOnInit(): void {

    const categoriaid = this.route.snapshot.params.id;
    this.tiposService.pegarTodos().subscribe(res =>{
      this.tipos = res;
    })

    this.categoriasSerivce.pegarCategoriaID(categoriaid).subscribe(res =>{
      this.formulario = new FormGroup({
        categoriaid: new FormControl(res.CategoriaID),
        nome: new FormControl(res.Nome),
        icone: new FormControl(res.Icone),
        tipoID: new FormControl(res.TipoID),
      });      
    })
  }

  get propriedade(){
    return this.formulario.controls;
  }

}
