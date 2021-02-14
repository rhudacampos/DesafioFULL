import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  constructor(private router: Router) {

  }

  isExpanded = false;

  public TituloPaschoalotto = "Paschoalotto";
  public enderecoPaschoalotto = "https://www.paschoalotto.com.br/";
  public enderecoLogoPaschoalotto = "https://www.paschoalotto.com.br/wp-content/uploads/2020/11/Logo-Paschoalotto-PNG-768x152-2.png";

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
    //var usuarioLogado = sessionStorage.getItem("usuario-autenticado");
    //if (usuarioLogado == "1") {
    //  return true;
    //}
    //return false;
    return sessionStorage.getItem("usuario-autenticado") == "1";
  }

  logout() {
    sessionStorage.setItem("usuario-autenticado", "0");
    this.router.navigate(["/"]);
  }

}
