using System;

namespace DesafioFULL.Dominio.ViewModels
{
    public class ViewModelTituloParcela
    {
        public long id { get; set; }
        public long tituloId { get; set; }
        public int numParcela { get; set; }
        public DateTime vencimento { get; set; }
        public DateTime _vencimento { get; set; }
        public decimal vlrOriginal { get; set; }
        public decimal vlrJuros { get; set; }
        public decimal vlrMulta { get; set; }
        public decimal vlrCorrigido { get; set; }
        public int diasEmAtraso { get; set; }

    }
}
