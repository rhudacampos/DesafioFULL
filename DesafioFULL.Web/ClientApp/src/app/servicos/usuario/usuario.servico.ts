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

  set usuario(usuario: Usuario) {
    sessionStorage.setItem("usuario-autenticado", JSON.stringify(usuario));
    this.usuarioSessao = usuario;
  }

  get usuario(): Usuario {
    let usuairo_json = sessionStorage.getItem("usuario-autenticado");
    this.usuarioSessao = JSON.parse(usuairo_json);
    return this.usuarioSessao;
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
  }

  public usuario_autenticado(): boolean {
    return this.usuarioSessao != null && this.usuarioSessao.email != "" && this.usuarioSessao.senha != "";
  }

  public limpar_sessao() {
    sessionStorage.setItem("usuario-autenticado", "");
    this.usuarioSessao = null;
  }
 

  public verificaUsuario(usuario: Usuario): Observable<Usuario> {

    const headers = new HttpHeaders().set('content-type', 'application/json');

    var body = {
      email: usuario.email,
      senha: usuario.senha
    }


    return this.http.post<Usuario>(this.baseURL + "usuario/verificarUsuario", body, { headers });
  }

  public cadastrarUsuario(usuario: Usuario): Observable<Usuario> {

    const headers = new HttpHeaders().set('content-type', 'application/json');

    var body = {
      email: usuario.email,
      senha: usuario.senha,
      nome: usuario.nome,
      sobreNome: usuario.sobreNome
    }

    return this.http.post<Usuario>(this.baseURL + "usuario", body, { headers });
  }

}
