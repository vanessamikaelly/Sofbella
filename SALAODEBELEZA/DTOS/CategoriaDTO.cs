using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class CategoriaDTO
    {
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Descricao { get; set; }
    }
}
