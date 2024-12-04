using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.Models
{
    public class Perfil
    { 
        public int Id { get; set; }
        public string Tipo_perfil { get; set; }
        public string Agenda { get; set; }
        public string Comissoes { get; set; }
        public string Financeiro { get; set; }
    }
}
