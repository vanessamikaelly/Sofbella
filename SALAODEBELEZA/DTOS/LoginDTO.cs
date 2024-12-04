using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "O número deve ter entre 8 e 10 caracteres.")]
        public string Senha { get; set; }
    }
}
