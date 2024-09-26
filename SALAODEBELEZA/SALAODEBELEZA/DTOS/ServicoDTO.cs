namespace SALAODEBELEZA.DTOS
{
    public class ServicoDTO
    {
        [Required]
        public string NomeServico { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public double PrecoUnitario { get; set; }
        [Required]
        public string DuracaoAtendimento { get; set; }
        [Required]
        public double Comissao { get; set; }
        [Required]
        public int Recorrencia { get; set; }

    }
}
