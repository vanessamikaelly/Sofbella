using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.Models
{
    public class BaixaInterna
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EstoqueAtual { get; set; }
        public int BaixarEstoque { get; set; }
        public string Descricao { get; set; }

        public int IdEstoqueFk { get; set; }
    }
}
