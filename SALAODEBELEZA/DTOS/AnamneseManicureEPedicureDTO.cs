using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.Models
{
    public class AnamneseManicureEPedicureDTO
    {

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Frequenca { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public bool RetiraCuticula { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public bool RoeUnhas { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public bool Alergia { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string DescricaoAlergia { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string FormatoPreferencia { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public bool TonalidadePreferida { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public bool UnhaEncravada { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public bool Micose { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string CorEsmalte { get; set; }
    }
}
