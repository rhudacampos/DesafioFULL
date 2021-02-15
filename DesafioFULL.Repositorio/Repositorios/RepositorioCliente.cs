using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.Interfaces.Repositorios;
using DesafioFULL.Repositorio.Contexto;

namespace DesafioFULL.Repositorio.Repositorios
{
    public class RepositorioCliente : RepositorioBase<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(DesafioFULLContexto desafioFULLContexto) : base(desafioFULLContexto)
        {
        }
    }
}
