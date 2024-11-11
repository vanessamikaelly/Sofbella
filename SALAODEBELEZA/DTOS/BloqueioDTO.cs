using System.ComponentModel.DataAnnotations;

namespace SOFBELLASALAOOO.DTO
{
    public class BloqueioDTO
    {
      
        [Required]
        public int Profissional { get; set; }  
        [Required]
        public DateTime DataInicio { get; set; }  
        [Required]
        public string HoraInicio { get; set; }   
        [Required]
        public DateTime DataFinal { get; set; }    
        [Required]
        public string HoraFinal { get; set; }   
        [Required]
        public string Motivo { get; set; }
        [Required]
        public bool DiaInteiro { get; set; }

    }

}

