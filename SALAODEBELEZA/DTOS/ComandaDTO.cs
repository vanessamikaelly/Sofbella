using System;
using System.ComponentModel.DataAnnotations;

namespace SOFBELLASALAOOO.DTO
{
    public class ComandaDTO
    {
        [Required]
        public DateTime Data { get; set; }  

        [Required]
        public int ClienteId { get; set; }  

        [Required]
        [EmailAddress(ErrorMessage = "O e-mail inserido não é válido.")]
        public string Email { get; set; }  

        [Required]
        [RegularExpression(@"\d{11}", ErrorMessage = "O CPF deve conter 11 dígitos.")]
        public string CPF { get; set; } 

        [Required]
        [Phone(ErrorMessage = "O número de telefone inserido não é válido.")]
        public string Telefone { get; set; }  
    }
}
