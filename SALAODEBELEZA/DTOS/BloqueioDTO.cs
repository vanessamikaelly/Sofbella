using System.ComponentModel.DataAnnotations;

namespace SOFBELLASALAOOO.DTO
{
    public class BloqueioDTO
    {

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public int Profissional { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string HoraInicio { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public DateTime DataFinal { get; set; }  
        
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string HoraFinal { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Motivo { get; set; }

        public bool DiaInteiro { get; set; }

    }

}

