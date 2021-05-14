import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Categoria } from '../models/Categoria';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'

  })
};

@Injectable({
  providedIn: 'root'
})
export class CategoriasService {

  url = 'api/categorias';

  constructor( private http: HttpClient ) { }

  pegarTodos(): Observable<Categoria[]> {
    return this.http.get<Categoria[]>(this.url);
  }
  
  pegarcategoriaID(categoriaID: number): Observable<Categoria> {
    const apiURL = `${this.url}/${categoriaID}`;
    return this.http.get<Categoria>(apiURL);
  }

  novaCategoria(categoria: Categoria): Observable<any> {
    return this.http.post<Categoria>(this.url, categoria, httpOptions);
  }

  atualizarCategoria(categoriaID: number, categoria: Categoria): Observable<any> {
    const apiURL = `${this.url}/${categoriaID}`;
    return this.http.put<Categoria>(apiURL, categoria, httpOptions);
  }

  excluirCategoria(categoriaID: number): Observable<any> {
    const apiURL = `${this.url}/${categoriaID}`;
    return this.http.delete<number>(apiURL, httpOptions);
  }

}
