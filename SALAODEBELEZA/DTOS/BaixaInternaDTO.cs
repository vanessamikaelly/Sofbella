using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class BaixaInternaDTO
    {

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
       
        public int BaixarEstoque { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Descricao { get; set; }

        [Required]
        public int IdEstoqueFk { get; set; }

    }
}
