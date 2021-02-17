using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.Interfaces.Repositorios;
using DesafioFULL.Repositorio.Contexto;
using System;
using System.Linq;

namespace DesafioFULL.Repositorio.Repositorios
{
    public class RepositorioTituloVerificacao : RepositorioBase<TituloVerificacao>, IRepositorioTituloVerificacao
    {
        public RepositorioTituloVerificacao(DesafioFULLContexto desafioFULLContexto) : base(desafioFULLContexto)
        {
        }

        public TituloVerificacao ObterVerificacaoAtual()
        {
            return _desafioFULLContexto.TituloVerificacoes.FirstOrDefault(
                    t => t.DataVerificacao == DateTime.Today);
        }
    }
}
