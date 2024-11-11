using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class CalendarioDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Servico { get; set; }
        [Required]
        public string Cliente { get; set; }
        [Required]
        public DateOnly Data { get; set; }
        [Required]
        public TimeOnly Hora { get; set; }
    }
}
