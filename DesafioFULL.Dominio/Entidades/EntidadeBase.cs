using System.Collections.Generic;
using System.Linq;

namespace DesafioFULL.Dominio.Entidades
{
    public abstract class EntidadeBase
    {
        public long Id { get; set; }
        private List<string> _mesagemValidacao { get; set; }
        private List<string> mensagemValidacao
        {
            get { return _mesagemValidacao ?? (_mesagemValidacao = new List<string>()); }
        }

        protected void LimparMensagensValidacao()
        {
            mensagemValidacao.Clear();
        }

        public void AdicionarMensagemValidacao(string mensagem)
        {
            mensagemValidacao.Add(mensagem);
        }

        public string ObterMensagensValidacao()
        {
            return string.Join(". ", mensagemValidacao);
        }


        public abstract void Validar();
        public bool EhValido
        {
            get { return !mensagemValidacao.Any(); }
        }

        
    }
}
