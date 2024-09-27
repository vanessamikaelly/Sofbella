using System;

namespace SOFBELLASALAOOO.Models
{
    
        public class Cliente
        {
            public string Nome { get; set; }  
            public int Id { get; set; }       

            public Cliente(int id, string nome)
            {
                Id = id;
                Nome = nome;
            }

            public override string ToString()
            {
                return $"ID: {Id}, Nome: {Nome}";
            }
        }
    

    public class Comanda
    {
        public DateTime Data { get; set; }             
        public Cliente Cliente { get; set; }           
        public string Email { get; set; }              
        public string CPF { get; set; }                
        public string Telefone { get; set; }           

        public Comanda(DateTime data, Cliente cliente, string email, string cpf, string telefone)
        {
            Data = data;
            Cliente = cliente;
            Email = email;
            CPF = cpf;
            Telefone = telefone;
        }

        
        public override string ToString()
        {
            return $"Data: {Data}, Cliente: {Cliente.Nome}, Email: {Email}, CPF: {CPF}, Telefone: {Telefone}";
        }
    }
}
