using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.Models
{
    public class Pacote
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Validade { get; set; }
        public string Itens { get; set; }
        public double Preco { get; set; }

    }
}
