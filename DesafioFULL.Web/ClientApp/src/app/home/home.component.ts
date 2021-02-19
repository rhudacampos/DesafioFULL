import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: ['img {  width: 80 %;  cursor: pointer;}  #imglogoPaschoalotto{width: 40%} #textoHome{ .px-2 {padding - right: ($spacer * .5)!important; }}']
})
export class HomeComponent {

  public TituloPaschoalotto = "Paschoalotto";
  public enderecoPaschoalotto = "https://www.paschoalotto.com.br/";
  public enderecoLogoPaschoalotto = "https://www.paschoalotto.com.br/wp-content/uploads/2020/11/Logo-Paschoalotto-PNG-768x152-2.png";

  linkPaschoalotto() {
    window.open(this.enderecoPaschoalotto, "_blank");
  }

}
