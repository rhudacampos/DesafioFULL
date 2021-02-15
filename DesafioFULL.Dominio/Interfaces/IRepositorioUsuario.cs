using DesafioFULL.Dominio.Entidades;

namespace DesafioFULL.Dominio.Interfaces
{
    public interface IRepositorioUsuario: IRepositorioBase<Usuario>
    {
        Usuario ObterPorAutenticacao(string email, string senha);
    }
}
