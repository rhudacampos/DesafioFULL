using DesafioFULL.Dominio.Entidades;

namespace DesafioFULL.Aplicacao.Interfaces
{
    public interface IAppServicoUsuario : IAppServicoBase<Usuario>
    {
        void Cadastrar(Usuario usuario);
        Usuario AutenticarUsuario(string email, string senha);
    }
}
