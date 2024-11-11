using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class ExpedienteDTO
    {

        [Required]
        public string Nome { get; set; }
        [Required]
        public string Dia { get; set; }
        [Required]
        public DateTime HoraEntrada { get; set; }
        [Required]
        public DateTime AlmoçoInicio { get; set; }
        [Required]
        public DateTime AlmoçoFinal { get; set; }
        [Required]
        public bool IntervaloAlmoço { get; set; }
        [Required]
        public DateTime HoraSaida { get; set; }
        [Required]
        public int FuncionarioIdFK { get; set; }
        
    }
}
