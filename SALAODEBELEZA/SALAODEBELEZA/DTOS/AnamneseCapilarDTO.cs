namespace SALAODEBELEZA.DTOS
{
    public class AnamneseCapilarDTO
    {
        [Required]
        public bool TipoCabelo { get; set; }
        [Required]
        public string Caracteristica { get; set; }
        [Required]
        public string Comprimento { get; set; }
        [Required]
        public string Pigmentacao { get; set; }
        [Required]
        public string Elasticidade { get; set; }
        [Required]
        public string Espessura { get; set; }
        [Required]
        public string Volume { get; set; }
        [Required]
        public string Condicao { get; set; }
        [Required]
        public string Observacoes { get; set; }
        [Required]
        public string AntecedentesAlerg { get; set; }
    }
}
