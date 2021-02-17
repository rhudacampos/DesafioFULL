
using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.Interfaces.Repositorios;
using DesafioFULL.Repositorio.Contexto;
using System.Linq;

namespace DesafioFULL.Repositorio.Repositorios
{
    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(DesafioFULLContexto desafioFULLContexto) : base(desafioFULLContexto)
        {
        }

        public Usuario ObterPorAutenticacao(string email, string senha)
        {
            return desafioFULLContexto.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public Usuario ObterPorEmail(string email)
        {
            return desafioFULLContexto.Usuarios.FirstOrDefault(u => u.Email == email);
        }
    }
}
