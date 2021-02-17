import { Component, OnInit } from "@angular/core"
import { Router } from "@angular/router";
import { Cliente } from "../../modelo/cliente";
import { ClienteServico } from "../../servicos/cliente/cliente.servico";

@Component({
  selector: "cliente",
  templateUrl: "./listagem.cliente.component.html",
  styleUrls: ["./listagem.cliente.component.css"]
})

export class ListagemClienteComponent implements OnInit {

  public clientes: Cliente[];

  constructor(private clienteServico: ClienteServico, private router: Router) {
    this.clienteServico.obterTodosClientes()
      .subscribe(
        retorno_json => {
          this.clientes = retorno_json;
        },
        e => {
          console.log(e.error);
        }
      );
  }

  ngOnInit(): void {
  }

  public adicionarCliente() {
    sessionStorage.setItem("clienteSessao", "");
    this.router.navigate(['/cadastro-cliente']);
  }

  public excluirCliente(cliente: Cliente) {
    var retorno = confirm("Deseja realmente excluir o cliente " + cliente.nome + " ?");
    if (retorno) {
      this.clienteServico.excluirCliente(cliente)
        .subscribe(
          retorno_json => {
            this.clientes = retorno_json;
          },
          e => {
            console.log(e.error);
          }
        )
    }
  }

  public editarCliente(cliente: Cliente) {
    sessionStorage.setItem('clienteSessao', JSON.stringify(cliente));
    this.router.navigate(['/cadastro-cliente']);
  }




}


