using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class ProfissionalDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Observacoes { get; set; }
        [Required]
        public string PossuiAgenda { get; set; }
        [Required]
        public string Ativo { get; set; }
        [Required]
        public string Expediente { get; set; }
        [Required]
        public DateTime Agenda { get; set; }
    }
}
