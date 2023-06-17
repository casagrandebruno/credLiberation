namespace credLiberation.Models
{
    public class Validacao
    {
        public double ValorMax { get; set; }
        public int QtdParcelasMin { get; set; }
        public int QtdParcelasMax { get; set; }
        public string TipoCliente { get; set; }
        public double ValorMinTipoCliente { get; set; }
        public int DtPrimeiroVencimentoMin { get; set; }
        public int DtPrimeiroVencimentoMax { get; set; }
    }
}