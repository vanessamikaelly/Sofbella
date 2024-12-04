using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class ClienteDTO
    {

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string NomeCli { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string EmailCli { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(11, MinimumLength = 9, ErrorMessage = "O número deve ter entre 9 e 11 caracteres.")]
        public string TelefoneCli { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(11, ErrorMessage = "O número deve ter apenas 11 caracteres.")]
        public string CPFCli { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string SexoCli { get; set; }
        [Required]
        public int IdEndFk { get; set; }
    }
}
