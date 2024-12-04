using Org.BouncyCastle.Asn1.X509;

namespace SOFBELLASALAOOO.Models
{
    public class Bloqueio
    {
            public int Id { get; set; }
            public int Profissional { get; set; }  
            public DateTime DataInicio { get; set; }  
            public DateTime HoraInicio { get; set; }   
            public DateTime DataFinal { get; set; }    
            public DateTime HoraFinal { get; set; }    
            public string Motivo { get; set; }
            public bool DiaInteiro { get; set; }
    }

}

