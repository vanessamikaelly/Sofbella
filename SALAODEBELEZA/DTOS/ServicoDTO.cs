using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class ServicoDTO
    {
        public string NomeServico { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public string DuracaoAtendimento { get; set; }
        public double Comissao { get; set; }
        public int IdCateFk { get; set; }
    }
}
