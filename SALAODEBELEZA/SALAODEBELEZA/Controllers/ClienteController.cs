using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.Models;


namespace SALAODEBELEZA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public static List<Cliente> listacliente = new List<Cliente>();
        public CienteController()
        {

        }

        [HttpGet]
        public ActionResult GetCliente()
        {
            return Ok(listacliente);

        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var cliente = listacliente.Where(item => item.Id == id).FirstOrDefault();

            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClienteDTO item)
        {
            var cliente = listacliente.Where(item => item.Id == id).FirstOrDefault();

            if (cliente == null)
            {
                return NotFound();
            }

            cliente.Endereco = item.Endereco;
            cliente.DataNascimento = item.DataNascimento;

            return Ok(listacliente);
        }

        [HttpDelete("{id}")]

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
