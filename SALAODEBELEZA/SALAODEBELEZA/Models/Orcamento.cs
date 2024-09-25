namespace SALAODEBELEZA.Models
{
    public class Orcamento
    {
        public int Id { get; set; } 
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public DateTime Validade { get; set; }
        public int Forma_Pagamento { get; set; }
        public string Observaçao { get; set; }

        //public servico Servicos { get; set;} dependencia
    }
}
