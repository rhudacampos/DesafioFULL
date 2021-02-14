import { Component } from "@angular/core"

@Component({
  selector: "app-cliente",
  template: "<html><body>{{ obterNome() }}</body></html>"
})

export class ClienteComponent {

  public nome: string;
  public sobreNome: string;
  public cpf: string;

  public obterNome(): string {
    //return this.nome;
    return "Cliente teste"
  }

}
