namespace SALAODEBELEZA.Models
{
    public class Orcamento
    {
        public int Id { get; set; } 
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int Forma_Pagamento { get; set; }
        public double Valor { get; set; }
        public int IdServFk { get; set; }
    }
}
