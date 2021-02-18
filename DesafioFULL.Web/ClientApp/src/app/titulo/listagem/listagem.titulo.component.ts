import { Component, OnInit } from "@angular/core"
import { Router } from "@angular/router";
import { Titulo } from "../../modelo/titulo";
import { TituloServico } from "../../servicos/titulo/titulo.servico";

@Component({
  selector: "titulos",
  templateUrl: "./listagem.titulo.component.html",
  styleUrls: ["./listagem.titulo.component.css"]
})

export class ListagemTituloComponent implements OnInit {

  public titulos: Titulo[];

  constructor(private tituloServico: TituloServico, private router: Router) {
    this.tituloServico.obterTodosTitulos()
      .subscribe(
        retorno_json => {
          this.titulos = retorno_json;
        },
        e => {
          console.log(e.error);
        }
      );
  }

  ngOnInit(): void {
  }  

  public adicionarTitulo() {
    sessionStorage.setItem("tituloSessao", "");
    this.router.navigate(['/manutencao-titulo']);
  }

  public excluirCliente(titulo: Titulo) {
    var retorno = confirm("Deseja realmente excluir esse titulo nº: " + titulo.id + " ?");
    if (retorno) {
      this.tituloServico.excluirTitulo(titulo)
        .subscribe(
          retorno_json => {
            this.titulos = retorno_json;
          },
          e => {
            console.log(e.error);
          }
        )
    }
  }

  public editarTitulo(titulo: Titulo) {
    sessionStorage.setItem('tituloSessao', JSON.stringify(titulo));
    this.router.navigate(['/manutencao-titulo']);
  }




}


