using System;

namespace DesafioFULL.Dominio.Entidades
{
    public class TituloParcela: EntidadeBase
    {
        public long TituloId { get; set; }
        public virtual Titulo Titulo { get; set; }
        public int NumParcela { get; set; }
        public DateTime Vencimento { get; set; }
        public decimal VlrOriginal { get; set; }
        public decimal VlrJuros { get; set; }
        public decimal VlrMulta { get; set; }
        public decimal VlrCorrigido { get; set; }
        public int DiasEmAtraso { get; set; }

        public override void Validar()
        {
            LimparMensagensValidacao();

            if (Vencimento == DateTime.MinValue)
                AdicionarMensagemValidacao("Necessita de um Vencimento valido");

            if (VlrOriginal <= 0)
                AdicionarMensagemValidacao("Necessita de um valor valido");

            if (NumParcela <= 0)
                AdicionarMensagemValidacao("Necessita de um valor de parcela valido");
        }
    }
}
