import { Component } from "@angular/core"
import { Cliente } from "../../modelo/cliente";
import { ClienteServico } from "../../servicos/cliente/cliente.servico";

@Component({
  selector: "clientes",
  templateUrl: "./listagem.cliente.component.html",
  styleUrls: ["./listagem.cliente.component.css"]
})

export class ListagemClienteComponent {

  public cliente: Cliente;
  
  constructor(private clienteServico: ClienteServico) {

  }

  ngOnInit(): void {
    this.cliente = new Cliente();
  }
    

}


