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

        public Cliente ObterPorCPF(string cpf)
        {
            return DesafioFULLContexto.Clientes.FirstOrDefault(c => c.CPF == cpf);
        }
    }
}
