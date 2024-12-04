using static Mysqlx.Expect.Open.Types.Condition.Types;
using System.Security.Cryptography.Xml;

namespace SALAODEBELEZA.Models
{
    public class Agenda
    {
        public int Id { get; set; }
        public DateTime Data { get; set;}
        public string Telefone { get; set; }
        public string NomeCliente { get; set; }
        public string Observacoes { get; set; }
        public string Responsavel { get; set; }
        public DateTime Hora { get; set; }
        public DateTime TempoAtendimento { get; set; }
        public string Servico { get; set; }
        public int IdProFk { get; set; }
        public int IdCliFk { get; set; }

    }
}
