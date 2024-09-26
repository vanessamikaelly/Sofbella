using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class PacoteDTO
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Unidade { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Codigo_barras { get; set; }
        [Required]
        public string Categoria { get; set; } /*aqui tem um método no diagrama de classe categoria: Categoria*/
        [Required]
        public double Preco { get; set; }
        [Required]
        public double Comissao { get; set; }
    }
}
