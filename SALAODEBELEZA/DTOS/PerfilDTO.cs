using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class PerfilDTO
    {

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Tipo_perfil { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Agenda { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Comissoes { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Financeiro { get; set; }

    }
}
