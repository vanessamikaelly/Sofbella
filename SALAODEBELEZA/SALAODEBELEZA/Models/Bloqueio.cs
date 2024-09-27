namespace SOFBELLASALAOOO.Models
{
    public class Bloqueio
    {
            public string Profissional { get; set; }  
            public DateTime DataInicio { get; set; }  
            public TimeSpan HoraInicio { get; set; }   
            public DateTime DataFinal { get; set; }    
            public TimeSpan HoraFinal { get; set; }    
            public string Motivo { get; set; }        
    }

}

