namespace SALAODEBELEZA.DTOS
{
    public class ClienteDTO
    {
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public string Endereco { get; set; }
     
    }
}
