import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UsuarioServico } from '../servicos/usuario/usuario.servico';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  constructor(private router: Router, private usuarioServico: UsuarioServico) {

  }

  isExpanded = false;

  public TituloPaschoalotto = "Paschoalotto";
  public enderecoPaschoalotto = "https://www.paschoalotto.com.br/";
  public enderecoLogoPaschoalotto = "https://www.paschoalotto.com.br/wp-content/uploads/2020/11/Logo-Paschoalotto-PNG-768x152-2.png";
  public emailLogado = "";
  public nomeLogado = "";

  linkPaschoalotto(){
    window.open(this.enderecoPaschoalotto, "_blank");
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  public usuarioLogado(): boolean {
    if (this.usuarioServico.usuario_autenticado()) {
      this.emailLogado = this.usuarioServico.usuarioSessao.email;
      this.nomeLogado = this.usuarioServico.usuarioSessao.nome;
      return true;
    }
    else {
      return false
    };
    
  }

  logout() {
    this.usuarioServico.limpar_sessao();
    this.router.navigate(["/"]);
  }

}
