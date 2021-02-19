using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.ViewModels;
using System.Collections.Generic;

namespace DesafioFULL.Aplicacao.Interfaces
{
    public interface IAppServicoTitulo : IAppServicoBase<Titulo>
    {
        IEnumerable<ViewModelTitulo> ObterListagemTitulos();
        void ValidarECadastrar(Titulo titulo);
        void ValidarEAtualizar(Titulo titulo);
        IEnumerable<ViewModelTitulo> ExcluirERetornarLista(Titulo titulo);
        TituloParcela CalcularTituloParcela(ref Titulo titulo, TituloParcela tituloParcela, int numParcela);
        Titulo CalcularTitulo(Titulo titulo);
        void ProcessarCalculoTitulos();
        bool CalculoEfetuado();

        void ValidarECadastrarParcela(TituloParcela tituloParcela);
        void ValidarEAtualizarParcela(TituloParcela tituloParcela);

        IEnumerable<ViewModelTituloParcela> ObterParcelasPorTitulo(Titulo titulo);
        IEnumerable<ViewModelTituloParcela> ExcluirParcelaERetornarLista(TituloParcela tituloParcela);

    }
}
