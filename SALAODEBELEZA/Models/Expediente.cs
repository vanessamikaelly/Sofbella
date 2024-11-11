namespace SALAODEBELEZA.Models
{
    public class Expediente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Dia { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime AlmoçoInicio { get; set; }
        public DateTime AlmoçoFinal { get; set; }
        public bool IntervaloAlmoço { get; set; }
        public DateTime HoraSaida { get; set; }
        public int FuncionarioIdFK { get; set; }
    }
}
