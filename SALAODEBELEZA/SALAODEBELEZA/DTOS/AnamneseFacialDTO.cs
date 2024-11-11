using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class AnamneseFacialDTO
    {
       
        [Required]
        public bool Gestante { get; set; }
        [Required]
        public bool Queda_Cabelo { get; set; }
        [Required]
        public bool Alergia { get; set; }
        [Required]
        public bool Medicacao { get; set; }
        [Required]
        public string TipodePele { get; set; }
    }
}
