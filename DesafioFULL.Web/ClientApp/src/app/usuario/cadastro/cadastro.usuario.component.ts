import { Component, OnInit } from "@angular/core";
import { Usuario } from "../../modelo/usuario";
import { UsuarioServico } from "../../servicos/usuario/usuario.servico";

@Component({
  selector: "cadastro-usuario",
  templateUrl: "./cadastro.usuario.component.html",
  styleUrls: ["./cadastro.usuario.component.css"]
})

export class CadastroUsuarioComponent implements OnInit {

  public usuario: Usuario;
  public ativarSpinner: boolean;
  public mensagem: string;
  public usuarioCadastrado: boolean;
  public alerta: boolean;

  constructor(private usuarioServico: UsuarioServico) {

  }

  ngOnInit(): void {
    this.usuario = new Usuario();
  }

  public cadastrar() {
    this.alerta = false;
    this.ativarSpinner = true;
    this.usuarioServico.cadastrarUsuario(this.usuario)
      .subscribe(
        retorno_json => {
          this.usuarioCadastrado = true;
          this.mensagem = "Usuario cadastrado com sucesso";
          this.ativarSpinner = false;
          this.alerta = false;
        },
        e => {
          this.alerta = true;
          this.mensagem = e.error;
          this.ativarSpinner = false;
        }
      );
  }
  
}
