using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class OrcamentoDTO
    {
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(300, ErrorMessage = "A observação deve ter no máximo 300 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public int Forma_Pagamento { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public double Valor {  get; set; }

        [Required]
        public int IdServFk {  get; set; }
    }
}
