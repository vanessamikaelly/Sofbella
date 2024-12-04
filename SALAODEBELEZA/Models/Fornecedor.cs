using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj {  get; set; }
        public string Site { get; set; }
        public int IdEndFk { get; set; }
    }
}
