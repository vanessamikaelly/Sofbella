using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class AnamneseCorporalDTO
    {
        
        [Required]
        public bool Depilacao { get; set; }
        [Required]
        public bool Alergia { get; set; }
        [Required]
        public string TipoAlergia { get; set; }
        [Required]
        public bool ProblemaPele { get; set; }
        [Required]
        public bool TratamentoDermatologico { get; set; }
        [Required]
        public bool Gestante { get; set; }
        [Required]
        public string TipoPele { get; set; }
        [Required]
        public bool VasosVarizes { get; set; }
        [Required]
        public string MetodosUtilizados { get; set; }
        [Required]
        public string Areas { get; set; }
        
    }
}
