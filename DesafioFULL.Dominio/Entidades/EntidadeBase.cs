using System.Collections.Generic;
using System.Linq;

namespace DesafioFULL.Dominio.Entidades
{
    public abstract class EntidadeBase
    {
        public long Id { get; set; }
        public List<string> _mesagemValidacao { get; set; }
        private List<string> mensagemValidacao
        {
            get { return _mesagemValidacao ?? (_mesagemValidacao = new List<string>()); }
        }

        protected void LimparMensagensValidacao()
        {
            mensagemValidacao.Clear();
        }

        protected void AdicionarMensagemValidacao(string mensagem)
        {
            mensagemValidacao.Add(mensagem);
        }

        public abstract void Validar();
        protected bool EhValido
        {
            get { return !mensagemValidacao.Any(); }
        }
    }
}
