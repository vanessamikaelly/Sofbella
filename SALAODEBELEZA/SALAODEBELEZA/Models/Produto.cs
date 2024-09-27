namespace SOFBELLASALAOOO.Models
{
    public class Produto
    {
            public string Nome { get; set; }               
            public int Unidade { get; set; }               
            public string Descricao { get; set; }          
            public string CodigoBarras { get; set; }       
            public string Categoria { get; set; }         
            public double Preco { get; set; }             
            public double PrecoCusto { get; set; }         
            public double Comissao { get; set; }          

           
            public Produto(string nome, int unidade, string descricao, string codigoBarras,
                           string categoria, double preco, double precoCusto, double comissao)
            {
                Nome = nome;
                Unidade = unidade;
                Descricao = descricao;
                CodigoBarras = codigoBarras;
                Categoria = categoria;
                Preco = preco;
                PrecoCusto = precoCusto;
                Comissao = comissao;
            }

            public override string ToString()
            {
                return $"Nome: {Nome}, Unidade: {Unidade}, Descrição: {Descricao}, Código de Barras: {CodigoBarras}, " +
                       $"Categoria: {Categoria}, Preço: {Preco}, Preço de Custo: {PrecoCusto}, Comissão: {Comissao}";
            }
        }
    }


