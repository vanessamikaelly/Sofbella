using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class PagamentoDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int FormaPagamento { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public double RestaPagar { get; set; }
        [Required]
        public double Desconto { get; set; }
    }
}
