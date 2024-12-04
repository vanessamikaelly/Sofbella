using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class AgendaDTO
    {
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(9, MinimumLength = 8, ErrorMessage = "O número deve ter entre 8 e 9 caracteres.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string NomeCliente { get; set; }

        [StringLength(300, ErrorMessage = "A observação deve ter no máximo 300 caracteres.")]
        public string Observacoes { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Responsavel { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public DateTime Hora { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public DateTime TempoAtendimento { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Servico { get; set; }

        [Required]
        public int IdProFk { get; set; }
        [Required]
        public int IdCliFk { get; set; }
    }
}
