using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
