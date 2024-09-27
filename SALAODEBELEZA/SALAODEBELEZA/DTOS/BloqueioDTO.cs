using System.ComponentModel.DataAnnotations;

namespace SOFBELLASALAOOO.DTO
{
    public class BloqueioDTO
    {
      
        
        [Required]
        public string Profissional { get; set; }  
        [Required]
        public DateTime DataInicio { get; set; }  
        [Required]
        public TimeSpan HoraInicio { get; set; }   
        [Required]
        public DateTime DataFinal { get; set; }    
        [Required]
        public TimeSpan HoraFinal { get; set; }   
        [Required]
        public string Motivo { get; set; }

    }

}

