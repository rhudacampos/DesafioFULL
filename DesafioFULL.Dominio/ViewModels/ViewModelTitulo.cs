namespace DesafioFULL.Dominio.ViewModels
{
    public class ViewModelTitulo
    {
        public long id { get; set; }
        public long clienteId { get; set; }
        public int qtdeParcelas { get; set; }
        public decimal perJuros { get; set; }
        public decimal perMulta { get; set; }
        public decimal vlrOriginal { get; set; }
        public decimal vlrCorrigido { get; set; }
        public int diasEmAtraso { get; set; }
        public string nomeCliente { get; set; }
        public string cpfCliente { get; set; }
        public decimal vlrJuros { get; set; }
        public decimal vlrMulta { get; set; }

    }
}
