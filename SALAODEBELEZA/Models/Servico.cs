namespace SALAODEBELEZA.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string NomeServico { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime DuracaoAtendimento { get; set; }
        public double Comissao { get; set; }
        public int IdCateFk { get; set; }
    }
}
