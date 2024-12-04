using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class ServicoDTO
    {
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string NomeServico { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public DateTime DuracaoAtendimento { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public double Comissao { get; set; }

        [Required]
        public int IdCateFk { get; set; }
    }
}
