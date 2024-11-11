using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class FornecedorDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Empresa { get; set; }
        [Required]
        public string Site { get; set; }
        //public endereco Endereco { get; set; } dependencia
    }
}
