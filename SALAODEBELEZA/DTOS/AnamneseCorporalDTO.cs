using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class AnamneseCorporalDTO
    {

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public bool Depilacao { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public bool Alergia { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string TipoAlergia { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public bool ProblemaPele { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public bool TratamentoDermatologico { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public bool Gestante { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string TipoPele { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public bool VasosVarizes { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string MetodosUtilizados { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Areas { get; set; }
        
    }
}
