import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
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
}
