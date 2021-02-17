using DesafioFULL.Dominio.Entidades;
using System.Collections.Generic;

namespace DesafioFULL.Aplicacao.Interfaces
{
    public interface IAppServicoCliente : IAppServicoBase<Cliente>
    {
        void ValidarECadastrar(Cliente cliente);
        void ValidarEAtualizar(Cliente cliente);
        IEnumerable<Cliente> ExcluirERetornarLista(Cliente cliente);

    }
}
