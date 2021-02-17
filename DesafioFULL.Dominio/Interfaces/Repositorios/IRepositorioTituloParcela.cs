using DesafioFULL.Dominio.Entidades;
using System.Collections.Generic;

namespace DesafioFULL.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioTituloParcela: IRepositorioBase<TituloParcela>
    {
        IList<TituloParcela> ObterPorTitulo(Titulo titulo);
    }
}
