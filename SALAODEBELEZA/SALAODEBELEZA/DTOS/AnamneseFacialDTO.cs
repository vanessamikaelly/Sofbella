using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class AnamneseFacialDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public bool Gestante { get; set; }
        [Required]
        public bool Queda_Cabelo { get; set; }
        [Required]
        public string Alergia { get; set; }
        [Required]
        public bool Medicacao { get; set; }
    }
}
