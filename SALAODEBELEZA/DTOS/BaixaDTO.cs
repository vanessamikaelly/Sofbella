using System.ComponentModel.DataAnnotations;

namespace SOFBELLASALAOOO.DTOS
{
    public class Baixa_automatica
    {
        
            [Required]
            [StringLength(255, ErrorMessage = "A descrição não pode exceder 255 caracteres.")]
            public string Descricao { get; set; }  
            [Required]
            public int Servico { get; set; }  

            [Required]
            public bool ConfirmarQuantidadeAoFinalizar { get; set; }  

            [Required]
            public bool PermitirAlterarProduto { get; set; }  
    }
}



