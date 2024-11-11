using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class BaixaInternaDTO
    {
        
        [Required]
        public string Nome { get; set; }
        [Required]
        public int EstoqueAtual { get; set; }
        [Required]
        public int BaixarEstoque { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int IdEstoqueFk { get; set; }

    }
}
