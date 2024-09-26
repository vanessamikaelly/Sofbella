namespace SALAODEBELEZA.Models
{
    public class Servico
    {
        public string NomeServico { get; set; }
        public string Descricao { get; set; }
        public double PrecoUnitario { get; set; }
        public string duracaoAtendimento { get; set; }
        public double comissao { get; set; }
        public int recorrencia { get; set; }

        /*public categoria Categoria {get; set;} dependecia*/
    }
}
