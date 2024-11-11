using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("pacotes")]
    [ApiController]
    public class PacotesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Pacote> listaPacotes = new PacoteDAO1().List();

            return Ok(listaPacotes);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PacoteDTO item)
        {
            var pacote = new Pacote
            {
                Nome = item.Nome,
                Validade = item.Validade,
                Itens = item.Itens,
                Preco = item.Preco
            };

            try
            {
                var dao = new PacoteDAO1();
                pacote.Id = dao.Insert(pacote);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", pacote);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var pacote = new PacoteDAO1().GetById(id);

                if (pacote == null)
                {
                    return NotFound();
                }

                return Ok(pacote);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PacoteDTO item)
        {
            try
            {
                var pacote = new PacoteDAO1().GetById(id);

                if (pacote == null)
                {
                    return NotFound();
                }

                pacote.Nome = item.Nome;
                pacote.Validade = item.Validade;
                pacote.Itens = item.Itens;
                pacote.Preco = item.Preco;

                new PacoteDAO1().Update(pacote);

                return Ok(pacote);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var pacote = new PacoteDAO1().GetById(id);

                if (pacote == null)
                {
                    return NotFound();
                }

                new PacoteDAO1().Delete(pacote.Id);

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }
    }
}
