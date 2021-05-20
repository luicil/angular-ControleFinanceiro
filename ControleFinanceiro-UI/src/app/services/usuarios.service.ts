import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DadosRegistro } from '../models/DadosRegistro';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  url = 'api/Usuarios';

  constructor( private http: HttpClient ) { }

  SalvarFoto(formData: any) : Observable<any>{
    const apiURL = `${this.url}/SalvarFoto`;
    return this.http.post<any>(apiURL, formData);
  }

  RegistrarUsuario(dadosRegistro: DadosRegistro): Observable<any>{
    const apiURL = `${this.url}/RegistrarUsuario`;
    return this.http.post<DadosRegistro>(apiURL, dadosRegistro);
  }

}
