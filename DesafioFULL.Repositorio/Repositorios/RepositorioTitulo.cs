using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.Interfaces;
using DesafioFULL.Repositorio.Contexto;

namespace DesafioFULL.Repositorio.Repositorios
{
    public class RepositorioTitulo : RepositorioBase<Titulo>, IRepositorioTitulo
    {
        public RepositorioTitulo(DesafioFULLContexto desafioFULLContexto) : base(desafioFULLContexto)
        {
        }
    }
}
