using System.ComponentModel.DataAnnotations;

namespace SOFBELLASALAOOO.DTOS
{
    public class ProdutoDTO
    {

            [Required(ErrorMessage = "O campo é obrigatório!")]
            [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
            public string Nome { get; set; }  
            public string Descricao { get; set; }  

            [Required(ErrorMessage = "O campo é obrigatório!")]
            [StringLength(13, ErrorMessage = "O código de barras deve ter 13 dígitos.")]
            public string CodigoBarras { get; set; }  

            [Required(ErrorMessage = "O campo é obrigatório!")]
            [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que 0.")]
            public double Preco { get; set; }  

            [Required(ErrorMessage = "O campo é obrigatório!")]
            [Range(0.01, double.MaxValue, ErrorMessage = "O preço de custo deve ser maior que 0.")]
            public double PrecoCusto { get; set; }  

            [Required(ErrorMessage = "O campo é obrigatório!")]
            [Range(0, 100, ErrorMessage = "A comissão deve estar entre 0 e 100%.")]
            public double Comissao { get; set; }
            [Required]
            public int IdCateFk { get; set; }
        }
    }

