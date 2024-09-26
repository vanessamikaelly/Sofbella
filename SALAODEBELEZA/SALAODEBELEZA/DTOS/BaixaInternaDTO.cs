using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class BaixaInternaDTO
    {
        
        [Required]
        public string Descricao { get; set; }

        [Required]
        public int Estoque_atual { get; set; }

    }
}
