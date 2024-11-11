namespace SALAODEBELEZA.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string NomeServico { get; set; }
        public string Descricao { get; set; }
        public double PrecoUnitario { get; set; }
        public string DuracaoAtendimento { get; set; }
        public double Comissao { get; set; }
        public int Recorrencia { get; set; }

        /*public categoria Categoria { get; set; }
        dependecia*/
    }
}
