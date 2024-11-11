namespace SALAODEBELEZA.Models
{
    public class AnamneseManicureEPedicure
    {
        public int Id { get; set; }
        public string Frequenca { get; set; }
        public bool RetiraCuticula { get; set; }
        public bool RoeUnhas { get; set; }
        public bool Alergia { get; set; }
        public string DescricaoAlergia { get; set; }
        public string FormatoPreferencia { get; set; }
        public bool TonalidadePreferida { get; set; }
        public bool UnhaEncravada { get; set; }
        public bool Micose { get; set; }
        public string CorEsmalte { get; set; }
    }

}
