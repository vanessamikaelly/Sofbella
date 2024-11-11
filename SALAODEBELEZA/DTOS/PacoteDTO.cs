using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class PacoteDTO
    {

        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime Validade { get; set; }
        [Required]
        public string Itens { get; set; }
        [Required]
        public double Preco { get; set; }
    }
}
