using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFULL.Dominio.Entidades
{
    public class Usuario: EntidadeBase
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }

        public override void Validar()
        {
            LimparMensagensValidacao();

            if (string.IsNullOrEmpty(Email))
                AdicionarMensagemValidacao("Email não pode ficar vazio");

            if (string.IsNullOrEmpty(Senha))
                AdicionarMensagemValidacao("Senha não pode ficar vazio");

            if (string.IsNullOrEmpty(Nome))
                AdicionarMensagemValidacao("Nome não pode ficar vazio");
           
        }
    }
}
