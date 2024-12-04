using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class EnderecoDTO
    {
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(8, ErrorMessage = "O número deve ter apenas 8 caracteres.")]
        public string CEP { get; set; }
    }
}
