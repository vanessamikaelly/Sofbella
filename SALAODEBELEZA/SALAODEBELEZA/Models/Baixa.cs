namespace SOFBELLASALAOOO.Models
{
    public class Baixa
    {
       
            public string Descricao { get; set; }                     
            public int Servico { get; set; }                           
            public bool ConfirmarQuantidadeAoFinalizar { get; set; }    
            public bool PermitirAlterarProduto { get; set; }            

            
            public Baixa(string descricao, int servico, bool confirmarQuantidadeAoFinalizar, bool permitirAlterarProduto)
            {
                Descricao = descricao;
                Servico = servico;
                ConfirmarQuantidadeAoFinalizar = confirmarQuantidadeAoFinalizar;
                PermitirAlterarProduto = permitirAlterarProduto;
            }

            
            public override string ToString()
            {
                return $"Descrição: {Descricao}, Serviço: {Servico}, Confirmar Quantidade: {ConfirmarQuantidadeAoFinalizar}, " +
                       $"Permitir Alterar Produto: {PermitirAlterarProduto}";
            }
        }
    }



