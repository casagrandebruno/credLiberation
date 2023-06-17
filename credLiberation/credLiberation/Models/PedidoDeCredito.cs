namespace credLiberation.Models
{
    public class PedidoDeCredito
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public string Tipo { get; set; }
        public int QtdParcelas { get; set; }
        public DateTime DtPrimeiroVencimento { get; set; }

        public Validacao Validacao { get; set; }
    }
}
