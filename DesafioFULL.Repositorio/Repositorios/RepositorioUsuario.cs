
using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.Interfaces;
using DesafioFULL.Repositorio.Contexto;

namespace DesafioFULL.Repositorio.Repositorios
{
    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(DesafioFULLContexto desafioFULLContexto) : base(desafioFULLContexto)
        {
        }
    }
}
