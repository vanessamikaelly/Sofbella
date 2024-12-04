using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaixaInternaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<BaixaInterna> listaBaixasInternas = new BaixaInternaDAO().List();

            return Ok(listaBaixasInternas);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BaixaInternaDTO item)
        {
            var baixaInterna = new BaixaInterna
            {
                Nome = item.Nome,
                BaixarEstoque = item.BaixarEstoque,
                Descricao = item.Descricao,
                IdEstoqueFk = item.IdEstoqueFk
            };

            try
            {
                var dao = new BaixaInternaDAO();
                baixaInterna.Id = dao.Insert(baixaInterna);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", baixaInterna);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var baixaInterna = new BaixaInternaDAO().GetById(id);

                if (baixaInterna == null)
                {
                    return NotFound();
                }

                return Ok(baixaInterna);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BaixaInternaDTO item)
        {
            try
            {
                var baixaInterna = new BaixaInternaDAO().GetById(id);

                if (baixaInterna == null)
                {
                    return NotFound();
                }

                baixaInterna.Nome = item.Nome;
                baixaInterna.BaixarEstoque = item.BaixarEstoque;
                baixaInterna.Descricao = item.Descricao;
                baixaInterna.IdEstoqueFk = item.IdEstoqueFk;

                new BaixaInternaDAO().Update(baixaInterna);

                return Ok(baixaInterna);
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
                var baixaInterna = new BaixaInternaDAO().GetById(id);

                if (baixaInterna == null)
                {
                    return NotFound();
                }

                new BaixaInternaDAO().Delete(baixaInterna.Id);

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }
    }
}
