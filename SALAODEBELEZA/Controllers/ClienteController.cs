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

        [HttpGet]
        public IActionResult Get()
        {
            List<Cliente> listaClientes = new ClienteDAO().List();

            return Ok(listaClientes);
        }

        [HttpGet("Buscar/id")]

        public IActionResult GetById(int id)
        {
            try
            {
                var cliente = new ClienteDAO().GetById(id);

                if (cliente == null)
                {
                    return NotFound();
                }

                return Ok(cliente);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
           
        }

        [HttpPut("Atualizar/id")]
        public IActionResult Put(int id, [FromBody] ClienteDTO item)
        {
            try
            {
                var cliente = new ClienteDAO().GetById(id);

                if (cliente == null)
                {
                    return NotFound();
                }

                cliente.DataNascimento = item.DataNascimento;
                cliente.CPFCli = item.CPFCli;
                cliente.EmailCli = item.EmailCli;
                cliente.NomeCli = item.NomeCli;
                cliente.SexoCli = item.SexoCli;
                cliente.TelefoneCli = item.TelefoneCli;
                cliente.IdEndFk = item.IdEndFk;


                new ClienteDAO().Update(cliente);

                return Ok(cliente);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            
        }

        [HttpPost("Cadastrar/id")]
        public IActionResult Post([FromBody] ClienteDTO item)
        {
            var cliente = new Cliente();
            cliente.DataNascimento = item.DataNascimento;
            cliente.CPFCli = item.CPFCli;
            cliente.EmailCli = item.EmailCli;
            cliente.NomeCli = item.NomeCli;
            cliente.SexoCli = item.SexoCli;
            cliente.TelefoneCli = item.TelefoneCli;
            cliente.IdEndFk = item.IdEndFk;

            try 
            { 
                var dao = new ClienteDAO();
                cliente.Id = dao.Insert(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", cliente);
        }

        [HttpDelete("Excluir/id")]

        public IActionResult Delete(int id)
        {
            try
            {
                var cliente = new ClienteDAO().GetById(id);

                if (cliente == null)
                {
                    return NotFound();
                }

                new ClienteDAO().Delete(cliente.Id);

                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
