import { Component } from "@angular/core"
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { Cliente } from "../../modelo/cliente";
import { Titulo } from "../../modelo/titulo";
import { ClienteServico } from "../../servicos/cliente/cliente.servico";
import { TituloServico } from "../../servicos/titulo/titulo.servico";

@Component({
  selector: "manutencao-titulo",
  templateUrl: "./manutencao.titulo.component.html",
  styleUrls: ["./manutencao.titulo.component.css"]
})

export class ManutencaoTituloComponent {

  public titulo: Titulo;
  public clientes: Observable<Cliente[]>;
  public cliente: Cliente;
  
  public ativarSpinner: boolean;
  public alerta: boolean;
  public mensagem: string;
  public salvarAtualizar: string;
  public tituloCadastrado: boolean;

  constructor(private tituloServico: TituloServico,
    private clienteServico: ClienteServico, private router: Router) {

  }


  public carregarCliente(clienteId) {

    this.clienteServico.obterClienteId(clienteId)
      .subscribe(
        retorno_json => {
          this.cliente = retorno_json;
          this.titulo.nomeCliente = this.cliente.nome;
          this.titulo.cpfCliente = this.cliente.cpf;
        },
        e => {
          console.log(e.error);
        }

    );
  }


  ngOnInit(): void {
    var tituloSessao = sessionStorage.getItem("tituloSessao");
    if (tituloSessao) {
      this.titulo = JSON.parse(tituloSessao);
      this.salvarAtualizar = 'Atualizar';

      this.carregarCliente(this.titulo.clienteId);

    } else {
      this.titulo = new Titulo();
      this.cliente = new Cliente();
      this.salvarAtualizar = 'Salvar';
    }

    this.clientes = this.clienteServico.obterTodosClientes();
  }

  onChangeCliente(clienteId) {
    
    this.titulo.clienteId = clienteId;
    this.carregarCliente(clienteId);
  }

  public cadastrar() {
    this.ativarSpinner = true;
    this.tituloServico.cadastrarTitulo(this.titulo)
      .subscribe(
        retorno_json => {
          this.tituloCadastrado = true;

          if (this.titulo.id > 0) {
            this.mensagem = "Titulo salvo com sucesso";
          } else {
            this.mensagem = "Titulo adicionado com sucesso";
          }

          this.titulo = retorno_json;
          this.ativarSpinner = false;
          this.alerta = false;
          //this.router.navigate(['/titulos']);
        },
        e => {
          this.alerta = true;
          this.mensagem = e.error;
          this.ativarSpinner = false;
        }
      );
  }

}


