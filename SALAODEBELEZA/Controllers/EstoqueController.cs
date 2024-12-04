using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;
using SOFBELLASALAOOO.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("estoque")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Estoque> listaEstoques = new EstoqueDAO().List();

            return Ok(listaEstoques);
        }

        [HttpPost]
        public IActionResult Post([FromBody] EstoqueDTO item)
        {
            var estoque = new Estoque
            {
                NomeProduto = item.NomeProduto,
                EstoqueAtual = item.EstoqueAtual,
                Entrada = item.Entrada,
                PrecoCompra = item.PrecoCompra,
                PrecoVenda = item.PrecoVenda,
                IdFornFk = item.IdFornFk,
                IdProdFk = item.IdProdFk
            };

            try
            {
                var dao = new EstoqueDAO();
                estoque.Id = dao.Insert(estoque);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", estoque);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var estoque = new EstoqueDAO().GetById(id);

                if (estoque == null)
                {
                    return NotFound();
                }

                return Ok(estoque);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EstoqueDTO item)
        {
            try
            {
                var estoque = new EstoqueDAO().GetById(id);

                if (estoque == null)
                {
                    return NotFound();
                }

                estoque.NomeProduto = item.NomeProduto;
                estoque.EstoqueAtual = item.EstoqueAtual;
                estoque.Entrada = item.Entrada;
                estoque.PrecoCompra = item.PrecoCompra;
                estoque.PrecoVenda = item.PrecoVenda;
                estoque.IdFornFk = item.IdFornFk;
                estoque.IdProdFk = item.IdProdFk;

                new EstoqueDAO().Update(estoque);

                return Ok(estoque);
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
                var estoque = new EstoqueDAO().GetById(id);

                if (estoque == null)
                {
                    return NotFound();
                }

                new EstoqueDAO().Delete(estoque.Id);

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }
    }

}
