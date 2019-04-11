import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoriasService {

  constructor(private http: HttpClient) { }

  obterCategorias(): Observable<any[]> {
    let url = environment.vendasEndpoint + '/categorias';
    return this.http.get<any[]>(url);
  }
}
