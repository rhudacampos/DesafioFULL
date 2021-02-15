using DesafioFULL.Dominio.Entidades;

namespace DesafioFULL.Aplicacao.Interfaces
{
    public interface IAppServicoUsuario : IAppServicoBase<Usuario>
    {
        Usuario AutenticarUsuario(string email, string senha);
    }
}
