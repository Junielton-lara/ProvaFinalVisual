import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pagamento } from '../models/pagamento';

@Injectable({
    providedIn: 'root'
})
export class PagamentoService {

    private baseUrl = "http://localhost:5000/api/formaPagamento";

    constructor(private http: HttpClient) { }

    create(item: Pagamento): Observable<Pagamento> {
        return this.http.post<Pagamento>(`${this.baseUrl}/create`, item)
    }

    get(): Observable<Pagamento[]> {
        return this.http.get<Pagamento[]>(
            `${this.baseUrl}/list`
        );
    }
}