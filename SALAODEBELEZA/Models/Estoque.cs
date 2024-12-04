using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace SALAODEBELEZA.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public int EstoqueAtual { get; set; }
        public int Entrada { get; set; }
        public double PrecoCompra {  get; set; }
        public double PrecoVenda { get; set; }
        public int IdFornFk {  get; set; }
        public int IdProdFk { get; set; }
        
    }
}
