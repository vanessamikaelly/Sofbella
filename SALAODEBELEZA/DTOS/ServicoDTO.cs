using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class ServicoDTO
    {
        public int Id { get; set; }
        public string NomeServico { get; set; }
        public string Descricao { get; set; }
        public double PrecoUnitario { get; set; }
        public string DuracaoAtendimento { get; set; }
        public double Comissao { get; set; }
    }
}
