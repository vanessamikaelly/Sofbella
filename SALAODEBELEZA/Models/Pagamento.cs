using System.Security.Cryptography.X509Certificates;

namespace SALAODEBELEZA.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public DateTime DataPagamento { get; set; }
        public string Cliente { get; set; }
        public double Valor { get; set; }
        public double Desconto { get; set; }
        public int FormaPagamento { get; set; }
        public int IdCaiFk { get; set; }
        public int IdServFk {  get; set; }
        public int IdOrcaFk { get; set; }
        public int IdCliFk { get; set; }
    }
}
