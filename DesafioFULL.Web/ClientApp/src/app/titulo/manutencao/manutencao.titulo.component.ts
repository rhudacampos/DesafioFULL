import { DatePipe } from "@angular/common";
import { Component } from "@angular/core"
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { Cliente } from "../../modelo/cliente";
import { Titulo } from "../../modelo/titulo";
import { TituloParcela } from "../../modelo/tituloParcela";
import { ClienteServico } from "../../servicos/cliente/cliente.servico";
import { TituloServico } from "../../servicos/titulo/titulo.servico";

@Component({
  selector: "manutencao-titulo",
  templateUrl: "./manutencao.titulo.component.html",
  styleUrls: ["./manutencao.titulo.component.css"]
})

export class ManutencaoTituloComponent {

  public titulo: Titulo;

  public tituloParcelas: TituloParcela[];
  public tituloParcela: TituloParcela;

  public clientes: Observable<Cliente[]>;
  public cliente: Cliente;
  
  public ativarSpinner: boolean;
  public ativarSpinnerParcela: boolean;

  public alerta: boolean;
  public alertaParcela: boolean;

  public mensagem: string;
  public mensagemParcela: string;

  public tituloCadastrado: boolean;
  public parcelaCadastrada: boolean;

  public salvarAtualizar: string;
  
  constructor(private tituloServico: TituloServico,
    private clienteServico: ClienteServico, private router: Router, private datepipe: DatePipe) {

  }

  public carregarCliente(clienteId) {

    this.cliente.id = clienteId;

    this.clienteServico.obterCliente(this.cliente)
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
    
    this.cliente = new Cliente();
    this.tituloParcela = new TituloParcela();
    var tituloSessao = sessionStorage.getItem("tituloSessao");

    if (tituloSessao) {
      this.titulo = JSON.parse(tituloSessao);
      this.cliente
      this.carregarCliente(this.titulo.clienteId);
      this.salvarAtualizar = 'Atualizar';
      this.tituloParcela.numParcela = this.titulo.qtdeParcelas + 1;
    } else {
      this.titulo = new Titulo();
      this.salvarAtualizar = 'Salvar';
      this.tituloParcela.numParcela = 1;
    }

    this.clientes = this.clienteServico.obterTodosClientes();

    this.tituloServico.obterTituloParcelasPorTitulo(this.titulo)
      .subscribe(
        retorno_json => {
          this.tituloParcelas = retorno_json;
        },
        e => {
          console.log(e.error)
        }
      );

  }

  public() {
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

          this.titulo = new Titulo();
          this.titulo = retorno_json;

          this.cliente.id = this.titulo.clienteId;

          this.clienteServico.obterCliente(this.cliente)
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

          
          this.ativarSpinner = false;
          this.alerta = false;
          
        },
        e => {
          this.alerta = true;
          this.mensagem = e.error;
          this.ativarSpinner = false;
        }
    );
  }

  public editarParcela(tituloParcela: TituloParcela) {

    this.tituloParcela = tituloParcela;
  }
  

  public excluirParcela(tituloParcela: TituloParcela) {
    this.ativarSpinnerParcela = true;
    this.tituloParcela.tituloId = this.titulo.id;

    var retorno = confirm("Deseja realmente excluir a parcela Nº " + tituloParcela.numParcela + " ?");
    if (retorno) {
      this.tituloServico.excluirTituloParcela(tituloParcela)
        .subscribe(
          retorno_json => {
            this.tituloParcelas = retorno_json;

            this.tituloServico.obterTituloAtualizado(this.titulo)
              .subscribe(
                retorno_json => {
                  this.titulo = new Titulo();
                  this.titulo = retorno_json;
                  this.tituloParcela.numParcela = this.titulo.qtdeParcelas + 1;
                },
                e => {
                  console.log(e.error)
                }
              );

            this.ativarSpinnerParcela = false;
            this.alerta = false;
            //this.router.navigate(['/titulos']);
          },
          e => {
            this.alertaParcela = true;
            this.mensagemParcela = e.error;
            this.ativarSpinnerParcela = false;
          }
        );  
    }

      
  }

  public adicionarTituloParcela() {
    this.ativarSpinnerParcela = true;
    this.tituloParcela.tituloId = this.titulo.id;
    
    this.tituloServico.cadastrarTituloParcela(this.tituloParcela)
      .subscribe(
        retorno_json => {
          this.parcelaCadastrada = true;

          if (this.tituloParcela.id > 0) {
            this.mensagemParcela = "Parcela salva com sucesso";
          } else {
            this.mensagemParcela = "Parcela adicionado com sucesso";
          }

          this.tituloParcela = new TituloParcela();
          this.tituloServico.obterTituloParcelasPorTitulo(this.titulo)
            .subscribe(
              retorno_json => {
                this.tituloParcelas = retorno_json;
              },
              e => {
                console.log(e.error)
              }
          );

          this.tituloServico.obterTituloAtualizado(this.titulo)
            .subscribe(
              retorno_json => {
                this.titulo = new Titulo();
                this.titulo = retorno_json;
                this.tituloParcela.numParcela = this.titulo.qtdeParcelas + 1;
              },
              e => {
                console.log(e.error)
              }
            );
          
          this.ativarSpinnerParcela = false;
          this.alerta = false;
          //this.router.navigate(['/titulos']);
        },
        e => {
          this.alertaParcela = true;
          this.mensagemParcela = e.error;
          this.ativarSpinnerParcela = false;
        }
      );
  }
}


