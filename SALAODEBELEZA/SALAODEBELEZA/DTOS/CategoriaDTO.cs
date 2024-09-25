using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class CategoriaDTO
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public bool Ativo { get; set; }
    }
}
