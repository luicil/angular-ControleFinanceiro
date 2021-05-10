import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tipo } from '../models/Tipo';

@Injectable({
  providedIn: 'root'
})
export class TiposService {

  url: string = "api/tipos";

  constructor( private http: HttpClient ) { }

  pegarTodos(): Observable<Tipo[]> {
    return this.http.get<Tipo[]>(this.url);
  }
}
