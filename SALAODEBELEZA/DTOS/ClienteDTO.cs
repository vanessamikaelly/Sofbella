﻿namespace SALAODEBELEZA.DTOS
{
    public class ClienteDTO
    {

        public int Id { get; set; }
        public string NomeCli { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string EmailCli { get; set; }
        public string TelefoneCli { get; set; }
        public string CPFCli { get; set; }
        public string SexoCli { get; set; }
    }
}
