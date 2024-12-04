using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
