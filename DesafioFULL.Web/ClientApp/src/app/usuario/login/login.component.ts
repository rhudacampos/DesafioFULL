import { Component, OnInit } from "@angular/core";
import { Usuario } from "../../modelo/usuario";
import { ActivatedRoute, Router } from "@angular/router";
import { UsuarioServico } from "../../servicos/usuario/usuario.servico";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})

export class LoginComponent implements OnInit {

  public usuario;
  public returnUrl: string;
  public mensagem: string;
  public ativarSpinner: boolean;

  constructor(private router: Router, private activatedRouter: ActivatedRoute,
    private usuarioServico: UsuarioServico) {
  }

  ngOnInit(): void {
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];
    this.usuario = new Usuario();
  }

  login() {
    this.ativarSpinner = true;
    this.usuarioServico.verificaUsuario(this.usuario)
      .subscribe(
        retorno_json => {
          
          this.usuarioServico.usuario = retorno_json;

          if (this.returnUrl == null) {
            this.router.navigate(['./']);
          } else {
            this.router.navigate([this.returnUrl]);
          }

          this.router.navigate([this.returnUrl]);
          
        },
        e => {
          console.log(e.error);
          this.mensagem = e.error;
          this.ativarSpinner = false;
        }
      );

    //if (this.usuario.email == "teste@teste.com" && this.usuario.senha == "123") {
    //  sessionStorage.setItem("usuario-autenticado", "1");
    //  this.router.navigate([this.returnUrl]);
    //}
  }

}
