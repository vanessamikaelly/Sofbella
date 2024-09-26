namespace SALAODEBELEZA.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int FormaPagamento { get; set; }
        public double Valor { get; set; }
        public double RestaPagar { get; set; }
        public double Desconto { get; set; }
    }
}
