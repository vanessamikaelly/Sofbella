using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.Models
{
    public class Pacote
    {
        public string Nome { get; set; }
        public int Unidade { get; set; }
        public string Descricao { get; set; }
        public string Codigo_barras { get; set; }

        public string Categoria { get; set; } //aqui tem um método no diagrama de classe categoria: Categoria. Professor disse para não fazer os métodos agora

        public double Preco { get; set; }

        public double Comissao { get; set; }
    }
}
