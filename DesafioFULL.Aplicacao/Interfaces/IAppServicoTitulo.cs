using DesafioFULL.Aplicacao.ViewModels;
using DesafioFULL.Dominio.Entidades;
using System.Collections.Generic;

namespace DesafioFULL.Aplicacao.Interfaces
{
    public interface IAppServicoTitulo : IAppServicoBase<Titulo>
    {
        IEnumerable<ViewModelTitulo> ObterListagemTitulos();
        void ValidarECadastrar(Titulo titulo);
        void ValidarEAtualizar(Titulo titulo);
        IEnumerable<Titulo> ExcluirERetornarLista(Titulo titulo);
        TituloParcela CalcularTituloParcela(ref Titulo titulo, TituloParcela tituloParcela);
        Titulo CalcularTitulo(Titulo titulo);
        void ProcessarCalculoTitulos();
        bool CalculoEfetuado();

    }
}
