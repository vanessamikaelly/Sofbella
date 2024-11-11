using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.Models;
using SALAODEBELEZA.DTOS;


namespace SALAODEBELEZA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        public static List<Cliente> listacliente = new List<Cliente>();
        public ClienteController()
        {

        }

        [HttpGet]
        public ActionResult GetCliente()
        {
            return Ok(listacliente);

        }

        [HttpGet("Buscar/id")]

        public IActionResult GetById(int id)
        {
            var cliente = listacliente.Where(item => item.Id == id).FirstOrDefault();

            return Ok(cliente);
        }

        [HttpPut("Atualizar/id")]
        public IActionResult Put(int id, [FromBody] ClienteDTO item)
        {
            var cliente = listacliente.Where(item => item.Id == id).FirstOrDefault();

            if (cliente == null)
            {
                return NotFound();
            }

            cliente.Id = item.Id;
            cliente.Endereco = item.Endereco;
            cliente.DataNascimento = item.DataNascimento;

            return Ok(listacliente);
        }

        [HttpPost("Cadastrar/id")]
        public IActionResult Post([FromBody] ClienteDTO item)
        {
            var cliente = new Cliente();
            cliente.Id = listacliente.Count + 1;
            cliente.Endereco = item.Endereco;
            cliente.DataNascimento = item.DataNascimento; ;

            return Ok("Categoria cadastrada com sucesso:" + item);
        }

        [HttpDelete("Excluir/id")]

        public IActionResult Delete(int id)
        {
            var cliente = listacliente.Where(item => item.Id == id).FirstOrDefault();

            if (cliente == null)
            {
                return NotFound();
            }

            listacliente.Remove(cliente);

            return Ok(cliente);
        }
    }
}
