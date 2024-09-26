using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class CaixaDTO
    {
        
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public double ValorInicial { get; set; }
    }
}
