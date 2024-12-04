using System.Globalization;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace SALAODEBELEZA.Models
{
    public class Endereco
    {
        public int Id { get; set;}
        public string Rua { get; set;}
        public string Bairro { get; set;}
        public string Numero { get; set;}
        public string Cidade { get; set;}
        public string Estado {  get; set;}
        public string Pais { get; set;}
        public string CEP { get; set;}

    }
}
