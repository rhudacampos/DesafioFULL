import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHandler, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Usuario } from "../../modelo/usuario";

@Injectable({
  providedIn: "root"
})

export class UsuarioServico {

  private baseURL: string;
  public usuarioSessao: Usuario;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
  }

  set usuario(usuario: Usuario) {
    sessionStorage.setItem("usuario-autenticado", JSON.stringify(usuario));
    this.usuarioSessao = usuario;
  }

  get usuario(): Usuario {
    let usuairo_json = sessionStorage.getItem("usuario-autenticado");
    this.usuarioSessao = JSON.parse(usuairo_json);
    return this.usuarioSessao;
  }

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }

  public usuario_autenticado(): boolean {
    return this.usuarioSessao != null && this.usuarioSessao.email != "" && this.usuarioSessao.senha != "";
  }

  public limpar_sessao() {
    sessionStorage.setItem("usuario-autenticado", "");
    this.usuarioSessao = null;
  }
 

  public verificaUsuario(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(this.baseURL + "usuario/verificarUsuario", JSON.stringify(usuario), { headers: this.headers });
  }

  public cadastrarUsuario(usuario: Usuario): Observable<Usuario> {
     return this.http.post<Usuario>(this.baseURL + "usuario/cadastrar", JSON.stringify(usuario), { headers: this.headers });
  }

}
