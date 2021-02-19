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
  
  public emailLogado = "";
  public nomeLogado = "";

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
