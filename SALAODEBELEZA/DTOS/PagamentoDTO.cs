using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class PagamentoDTO
    {
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public DateTime DataPagamento { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public double Valor { get; set; }

        public double Desconto { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public int FormaPagamento { get; set; }

        [Required]
        public int IdCaiFk { get; set; }
        [Required]
        public int IdServFk { get; set; }
        public int IdOrcaFk { get; set; }
        [Required]
        public int IdCliFk { get; set; }
    }
}
