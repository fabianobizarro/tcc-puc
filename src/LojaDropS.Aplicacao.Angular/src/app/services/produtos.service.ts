import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProdutosService {

  defaultHeader = {
    'Access-Control-Allow-Origin': '*'
  }
  constructor(private http: HttpClient) { }

  pesquisarProdutos(query: string, page: number = 1): Observable<any[]> {
    let url = `${environment.vendasEndpoint}/produtos?q=${encodeURI(query)}&page=${page}`;
    return this.http.get<any[]>(url, { headers: this.defaultHeader });
  }
}
