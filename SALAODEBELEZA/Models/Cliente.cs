using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NomeCli { get; set; }
        public DateTime DataNascimento { get; set; }
        public string EmailCli { get; set; }
        public string TelefoneCli { get; set; }
        public string CPFCli { get; set; }
        public string SexoCli { get; set; }
        public int IdEndFk { get; set; }
    }
}
