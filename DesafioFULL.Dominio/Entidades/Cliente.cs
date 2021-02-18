using DesafioFULL.Dominio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFULL.Dominio.Entidades
{
    public class Cliente: EntidadeBase
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string CPF { get; set; }
        public string Fone { get; set; }
         
        public virtual ICollection<Titulo> Titulos { get; set; }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
                AdicionarMensagemValidacao("Nome não pode ficar vazio");
               
            if (string.IsNullOrEmpty(CPF))
                AdicionarMensagemValidacao("CPF não pode ficar vazio");
        }
    }
}
