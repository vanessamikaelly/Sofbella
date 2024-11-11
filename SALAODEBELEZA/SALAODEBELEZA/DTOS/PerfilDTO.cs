using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class PerfilDTO
    {

        [Required]
        public string Tipo_perfil { get; set; }

        [Required]
        public string Agenda { get; set; }

        [Required]
        public string Comissoes { get; set; }

        [Required]
        public string Financeiro { get; set; }

    }
}
