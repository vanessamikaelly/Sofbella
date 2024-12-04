using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class PacoteDTO
    {

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public double Valor{ get; set; }
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public DateTime Validade { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Itens { get; set; }
      
    }
}
