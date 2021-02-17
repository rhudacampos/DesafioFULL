using DesafioFULL.Aplicacao.Interfaces;
using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.Interfaces.Repositorios;
using DesafioFULL.Repositorio.Contexto;
using System.Collections.Generic;

namespace DesafioFULL.Aplicacao.Serviços
{
    public class AppServicoCliente:  AppServicoBase<Cliente>, IAppServicoCliente
    {
        private readonly IRepositorioCliente _repositorioCliente;

        public AppServicoCliente(DesafioFULLContexto desafioFULLContexto, IRepositorioCliente repositorioCliente) : base(desafioFULLContexto)
        {
            _repositorioCliente = repositorioCliente;
        }

        public void ValidarECadastrar(Cliente cliente)
        {
            try
            {
                var cpfCadastrado = _repositorioCliente.ObterPorCPF(cliente);
                if (cpfCadastrado != null)
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

        public void ValidarEAtualizar(Cliente cliente)
        {
            try
            {
                var cpfCadastrado = _repositorioCliente.ObterPorCPF(cliente);
                if (cpfCadastrado != null)
                    cliente.AdicionarMensagemValidacao("Este CPF já existe cadastrado no sistema");

                cliente.Validar();
                if (!cliente.EhValido)
                {
                    throw new System.ArgumentException(cliente.ObterMensagensValidacao());
                }

                _repositorioCliente.Atualizar(cliente);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IEnumerable<Cliente> ExcluirERetornarLista(Cliente cliente)
        {
            try
            {
                _repositorioCliente.Remover(cliente);
                return _repositorioCliente.ObterTodos();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
