using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class OrcamentoDTO
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public DateTime Validade { get; set; }
        [Required]
        public int Forma_Pagamento { get; set; }
        [Required]
        public string Observaçao { get; set; }

        //public servico Servicos { get; set;} dependencia
    }
}
