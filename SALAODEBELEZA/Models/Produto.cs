namespace SOFBELLASALAOOO.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string CodigoBarras { get; set; }
        public double Preco { get; set; }
        public double PrecoCusto { get; set; }
        public double Comissao { get; set; }
        public int IdCateFk { get; set; }
    }
}


