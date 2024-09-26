using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.Models
{
    public class AnamneseManicureEPedicureDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Frequenca { get; set; }
        [Required]
        public bool RetiraCuticula { get; set; }
        [Required]
        public bool RoeUnhas { get; set; }
        [Required]
        public bool Alergia { get; set; }
        [Required]
        public string DescricaoAlergia { get; set; }
        [Required]
        public string FormatoPreferencia { get; set; }
        [Required]
        public string TonalidadePreferida { get; set; }
        [Required]
        public bool UnhaEncravada { get; set; }
        [Required]
        public bool TeveOnocomicose { get; set; }
    }
}
