using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class EstoqueDTO
    {
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string NomeProduto { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public int EstoqueAtual { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public int Entrada { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public double PrecoCompra { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public double PrecoVenda { get; set; }

        [Required]
        public int IdFornFk { get; set; }
        [Required]
        public int IdProdFk { get; set; }
    }
}
