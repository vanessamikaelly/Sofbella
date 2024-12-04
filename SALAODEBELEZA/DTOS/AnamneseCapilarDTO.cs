using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class AnamneseCapilarDTO
    {
        [Required (ErrorMessage = "O campo é obrigatório!")]
        public bool TipoCabelo { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Caracteristica { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Comprimento { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Pigmentacao { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Elasticidade { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Espessura { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Volume { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Condicao { get; set; }

        public string Observacoes { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string AntecedentesAlerg { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string Resistencia { get; set; }

    }
}
