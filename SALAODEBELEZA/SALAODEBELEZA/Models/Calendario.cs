namespace SALAODEBELEZA.Models
{
    public class Calendario
    {
        public int Id { get; set; }
        public string Servico { get; set; }
        public string Cliente { get; set; }
        public DateOnly Data { get; set; }
        public TimeOnly Hora { get; set; }
    }
}
