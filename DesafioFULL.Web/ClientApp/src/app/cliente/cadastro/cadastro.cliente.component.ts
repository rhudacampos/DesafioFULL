import { Component } from "@angular/core"
import { Router } from "@angular/router";
import { Cliente } from "../../modelo/cliente";
import { ClienteServico } from "../../servicos/cliente/cliente.servico";

@Component({
  selector: "cadastro-cliente",
  templateUrl: "./cadastro.cliente.component.html",
  styleUrls: ["./cadastro.cliente.component.css"]
})

export class CadastroClienteComponent {

  public cliente: Cliente;
  public ativarSpinner: boolean;
  public alerta: boolean;
  public mensagem: string;
  public cadastrarAtualizar: string;
  public clienteCadastrado: boolean;

  constructor(private clienteServico: ClienteServico, private router: Router) {

  }

  ngOnInit(): void {
    var clienteSessao = sessionStorage.getItem("clienteSessao");
    if (clienteSessao) {
      this.cliente = JSON.parse(clienteSessao);
      this.cadastrarAtualizar = 'Atualizar';
    } else {
      this.cliente = new Cliente();
      this.cadastrarAtualizar = 'Cadastrar';
    }
  }


  public cadastrar() {
    this.ativarSpinner = true;
    this.clienteServico.cadastrarCliente(this.cliente)
      .subscribe(
        retorno_json => {
          this.clienteCadastrado = true;
          this.mensagem = "Cliente cadastrado com sucesso";
          this.ativarSpinner = false;
          this.alerta = false;
          this.router.navigate(['/clientes']);
        },
        e => {
          this.alerta = true;
          this.mensagem = e.error;
          this.ativarSpinner = false;
        }
      );
  }

}


