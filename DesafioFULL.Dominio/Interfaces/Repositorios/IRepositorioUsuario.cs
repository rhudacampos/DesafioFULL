using DesafioFULL.Dominio.Entidades;

namespace DesafioFULL.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioUsuario: IRepositorioBase<Usuario>
    {
        Usuario ObterPorAutenticacao(string email, string senha);
        Usuario ObterPorEmail(string email);
    }
}
