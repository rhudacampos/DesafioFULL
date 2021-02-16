using DesafioFULL.Aplicacao.Interfaces;
using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.Interfaces.Repositorios;
using DesafioFULL.Repositorio.Contexto;

namespace DesafioFULL.Aplicacao.Serviços
{
    public class AppServicoCliente:  AppServicoBase<Cliente>, IAppServicoCliente
    {
        private readonly IRepositorioCliente _repositorioCliente;

        public AppServicoCliente(DesafioFULLContexto desafioFULLContexto, IRepositorioCliente repositorioCliente) : base(desafioFULLContexto)
        {
            _repositorioCliente = repositorioCliente;
        }
        
    }
}
