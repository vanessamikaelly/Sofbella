namespace SALAODEBELEZA.Models
{
    public class Caixa
    {
        //public profissional Usuario { get; set; } dependencia
        public int Id { get; set; }
        public string UsuarioCaixa { get; set; }
        public DateTime DataInicio { get; set; }
        public double ValorInicial { get; set; }
        public double EntradaCaixa { get; set; }
        public double SaidaCaixa { get; set; }
        public double SaldoFinal {  get; set; }


    }
}
