using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class ExpedienteDTO
    {
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Dia { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public DateTime HoraEntrada { get; set; }
        
        public DateTime AlmoçoInicio { get; set; }
        
        public DateTime AlmoçoFinal { get; set; }

        public bool IntervaloAlmoço { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public DateTime HoraSaida { get; set; }

        [Required]
        public int FuncionarioIdFK { get; set; }
        
    }
}
