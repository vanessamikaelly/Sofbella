using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class FornecedorDTO
    {

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string NomeFantasia { get; set; }


        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string RazaoSocial { get; set; }


        [Required(ErrorMessage = "O campo é obrigatório!")]
        [StringLength(14, ErrorMessage = "O número deve ter no máximo 14 caracteres.")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Site { get; set; }

        [Required]
        public int IdEndFk { get; set; }
    }
}
