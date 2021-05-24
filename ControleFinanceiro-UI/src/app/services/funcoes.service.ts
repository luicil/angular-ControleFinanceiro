import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Funcao } from '../models/Funcao';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${localStorage.getItem('tokenUsuarioLogado')}`
  })
};


@Injectable({
  providedIn: 'root'
})
export class FuncoesService {

url = 'api/Funcoes';

  constructor( private http: HttpClient ) { }

  pegarTodos(): Observable<Funcao[]>{
    return this.http.get<Funcao[]>(this.url);
  }

  pegarFuncaoID(funcaoID: string): Observable<Funcao> {
    const apiURL = `${this.url}/${funcaoID}`;
    return this.http.get<Funcao>(apiURL);
  }

  novaFuncao(funcao: Funcao): Observable<any> {
    return this.http.post<Funcao>(this.url, funcao, httpOptions);
  }
  atualizarFuncao(funcaoID: string, funcao: Funcao): Observable<any> {
    const apiURL = `${this.url}/${funcaoID}`;
    return this.http.put<Funcao>(apiURL, funcao, httpOptions);
  }

  excluirFuncao(funcaoID: string): Observable<any> {
    const apiURL = `${this.url}/${funcaoID}`;
    return this.http.delete<number>(apiURL, httpOptions);
  }

  filtrarFuncoes(filtro: string) : Observable<Funcao[]> {
    const apiURL = `${this.url}/FiltrarFuncoes/${filtro}`;
    return this.http.get<Funcao[]>(apiURL);
  }

}
