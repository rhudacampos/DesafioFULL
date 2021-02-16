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

        public void Cadastrar(Cliente cliente)
        {
            try
            {
                var clienteCadastrado = _repositorioCliente.ObterPorCPF(cliente.CPF);
                if (clienteCadastrado != null)
                    cliente.AdicionarMensagemValidacao("CPF de cliente já cadastrado no sistema");

                cliente.Validar();
                if (!cliente.EhValido)
                {
                    throw new System.ArgumentException(cliente.ObterMensagensValidacao());
                } 

                _repositorioCliente.Adicionar(cliente);
            }
            catch (System.Exception)
            {
                throw;
            }

        }

    }
}
