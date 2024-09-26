using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class ExpedienteDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Dia { get; set; }
        [Required]
        public DateTime HoraEntrada { get; set; }
        [Required]
        public DateTime HoraInicioIntervalo { get; set; }
        [Required]
        public DateTime HoraFinalIntervalo { get; set; }
        [Required]
        public DateTime HoraSaida { get; set; }
    }
}
