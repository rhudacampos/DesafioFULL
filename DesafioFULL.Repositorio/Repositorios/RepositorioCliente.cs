using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.Interfaces.Repositorios;
using DesafioFULL.Repositorio.Contexto;
using System.Linq;

namespace DesafioFULL.Repositorio.Repositorios
{
    public class RepositorioCliente : RepositorioBase<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(DesafioFULLContexto desafioFULLContexto) : base(desafioFULLContexto)
        {
        }

        public Cliente ObterPorCPF(Cliente cliente)
        {
            // para validar cpf cadasrado no caso de uma atualização de cadastro
            if (cliente.Id > 0)
            {
                return DesafioFULLContexto.Clientes.FirstOrDefault(
                    c => c.CPF == cliente.CPF && c.Id != cliente.Id);
            }
            else
            {
                return DesafioFULLContexto.Clientes.FirstOrDefault(c => c.CPF == cliente.CPF);
            }
            
        }
    }
}
