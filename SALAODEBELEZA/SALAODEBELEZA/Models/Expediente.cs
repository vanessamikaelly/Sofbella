namespace SALAODEBELEZA.Models
{
    public class Expediente
    {
        public int Id { get; set; }
        public int Dia { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraInicioIntervalo { get; set; }
        public DateTime HoraFinalIntervalo { get; set; }
        public DateTime HoraSaida { get; set; }
    }
}
