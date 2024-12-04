using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class AnamneseFacialDTO
    {

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public bool Gestante { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public bool Queda_Cabelo { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public bool Alergia { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public bool Medicacao { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string TipodePele { get; set; }
    }
}
