using System.ComponentModel.DataAnnotations;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Mvc.Routing;

namespace SALAODEBELEZA.Models
{
    public class Profissional
    {
        public int Id { get; set; }
        public string NomePro { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
        public string Observacoes { get; set; }
        public string Expediente { get; set; }
        public string Possui_Agenda { get; set; }
        public string Ativo { get; set; }
        public int IdCateFk { get; set; }
        public int IdLogFk { get; set; }
        public int IdPerfFk { get; set; }
        public int IdEndFk { get; set; }
    }
}
