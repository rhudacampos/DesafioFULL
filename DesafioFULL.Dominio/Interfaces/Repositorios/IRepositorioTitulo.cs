using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.ViewModels;
using System.Collections.Generic;

namespace DesafioFULL.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioTitulo: IRepositorioBase<Titulo>
    {
        IEnumerable<ViewModelTitulo> ObterTodosTitulos();
        
    }
}
