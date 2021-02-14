using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.Interfaces;
using DesafioFULL.Repositorio.Contexto;

namespace DesafioFULL.Repositorio.Repositorios
{
    public class RepositorioTituloParcela : RepositorioBase<TituloParcela>, IRepositorioTituloParcela
    {
        public RepositorioTituloParcela(DesafioFULLContexto desafioFULLContexto) : base(desafioFULLContexto)
        {
        }
    }
}
