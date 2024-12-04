using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class ProfissionalDTO
    {
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string NomePro { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(11, MinimumLength = 9, ErrorMessage = "O número deve ter entre 9 e 11 caracteres.")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(11, ErrorMessage = "O número deve ter apenas 11 caracteres.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(300, ErrorMessage = "As observacoes deve ter apenas 300 caracteres.")]
        public string Observacoes { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Expediente { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public bool Possui_Agenda { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public bool Ativo { get; set; }

        [Required]
        public int IdCateFk { get; set; }

        [Required]
        public int IdLogFk { get; set; }

        [Required]
        public int IdPerfFk { get; set; }

        [Required]
        public int IdEndFk { get; set; }
    }
}
