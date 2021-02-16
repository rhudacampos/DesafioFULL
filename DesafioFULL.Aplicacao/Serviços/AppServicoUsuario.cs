using DesafioFULL.Aplicacao.Interfaces;
using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.Interfaces.Repositorios;
using DesafioFULL.Repositorio.Contexto;

namespace DesafioFULL.Aplicacao.Serviços
{
    public class AppServicoUsuario:  AppServicoBase<Usuario>, IAppServicoUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public AppServicoUsuario(DesafioFULLContexto desafioFULLContexto, IRepositorioUsuario repositorioUsuario) : base(desafioFULLContexto)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        
        public Usuario AutenticarUsuario(string email, string senha)
        {
            return _repositorioUsuario.ObterPorAutenticacao(email, senha);
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                var usuarioCadastrado = _repositorioUsuario.ObterPorEmail(usuario.Email);
                if (usuarioCadastrado != null)
                    throw new System.ArgumentException("Email de usuário já cadastrado no sistema");

                _repositorioUsuario.Adicionar(usuario);

            }
            catch (System.Exception)
            {
                throw;
            }

        }
    }
}
