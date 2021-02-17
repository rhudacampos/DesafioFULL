import { Injectable, Inject, OnInit } from "@angular/core";
import { HttpClient, HttpHandler, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Cliente } from "../../modelo/cliente";

@Injectable({
  providedIn: "root"
})

export class ClienteServico implements OnInit {

  private baseURL: string;
  public clientes: Cliente[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
  }
    ngOnInit(): void {
      this.clientes = [];
    }

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }

  public cadastrarCliente(cliente: Cliente): Observable<Cliente> {
    return this.http.post<Cliente>(this.baseURL + "cliente", JSON.stringify(cliente), { headers: this.headers });
  }

  public atualizarCliente(cliente: Cliente): Observable<Cliente> {
    return this.http.post<Cliente>(this.baseURL + "cliente", JSON.stringify(cliente), { headers: this.headers });
  }

  public excluirCliente(cliente: Cliente): Observable<Cliente[]> {
    return this.http.post<Cliente[]>(this.baseURL + "cliente/excluir", JSON.stringify(cliente), { headers: this.headers });
  }

  public obterTodosClientes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.baseURL + "cliente");
  }

  public obterCliente(): Observable<Cliente> {
    return this.http.get<Cliente>(this.baseURL + "cliente/obter");
  }
}
