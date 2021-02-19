import { Injectable, Inject, OnInit } from "@angular/core";
import { HttpClient, HttpHandler, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Titulo } from "../../modelo/titulo";
import { TituloParcela } from "../../modelo/tituloParcela";

@Injectable({
  providedIn: "root"
})

export class TituloServico implements OnInit {

  private baseURL: string;
  public titulos: Titulo[];
  public tituloParcelas: TituloParcela[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
  }
    ngOnInit(): void {
      this.titulos = [];
    }

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }

  public cadastrarTitulo(titulo: Titulo): Observable<Titulo> {
    return this.http.post<Titulo>(this.baseURL + "titulo", JSON.stringify(titulo), { headers: this.headers });
  }

  public atualizarTitulo(titulo: Titulo): Observable<Titulo> {
    return this.http.post<Titulo>(this.baseURL + "titulo", JSON.stringify(titulo), { headers: this.headers });
  }

  public excluirTitulo(titulo: Titulo): Observable<Titulo[]> {
    return this.http.post<Titulo[]>(this.baseURL + "titulo/excluir", JSON.stringify(titulo), { headers: this.headers });
  }
  
  public obterTodosTitulos(): Observable<Titulo[]> {
    return this.http.get<Titulo[]>(this.baseURL + "titulo");
  }

  public obterTituloParcelasPorTitulo(titulo: Titulo): Observable<TituloParcela[]> {
    return this.http.post<TituloParcela[]>(this.baseURL + "tituloParcela/parcelasPorTitulo", JSON.stringify(titulo), { headers: this.headers });
  }

  public cadastrarTituloParcela(tituloParela: TituloParcela): Observable<TituloParcela> {
    return this.http.post<TituloParcela>(this.baseURL + "tituloParcela", JSON.stringify(tituloParela), { headers: this.headers });
  }
  
  public obterTituloAtualizado(titulo: Titulo): Observable<Titulo> {
    return this.http.post<Titulo>(this.baseURL + "titulo/obterTitulo", JSON.stringify(titulo), { headers: this.headers });
  }

  public excluirTituloParcela(tituloParcela: TituloParcela): Observable<TituloParcela[]> {
    return this.http.post<TituloParcela[]>(this.baseURL + "tituloParcela/excluir", JSON.stringify(tituloParcela), { headers: this.headers });
  }
  
}
