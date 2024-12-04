using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.Models;
using SOFBELLASALAOOO.DTO;
using SOFBELLASALAOOO.DTOS;
using SOFBELLASALAOOO.Models;
using System.Collections.Generic;
using System.Linq;

namespace SOFBELLASALAOOO.Controllers
{
    [Route("produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Produto> listaProdutos = new ProdutoDAO().List();

            return Ok(listaProdutos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoDTO item)
        {
            var produto = new Produto
            {
                Nome = item.Nome,
                Descricao = item.Descricao,
                CodigoBarras = item.CodigoBarras,
                Preco = item.Preco,
                PrecoCusto = item.PrecoCusto,
                Comissao = item.Comissao,
                IdCateFk = item.IdCateFk
            };

            try
            {
                var dao = new ProdutoDAO();
                produto.Id = dao.Insert(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", produto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var produto = new ProdutoDAO().GetById(id);

                if (produto == null)
                {
                    return NotFound();
                }

                return Ok(produto);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProdutoDTO item)
        {
            try
            {
                var produto = new ProdutoDAO().GetById(id);

                if (produto == null)
                {
                    return NotFound();
                }

                produto.Nome = item.Nome;
                produto.Descricao = item.Descricao;
                produto.CodigoBarras = item.CodigoBarras;
                produto.Preco = item.Preco;
                produto.PrecoCusto = item.PrecoCusto;
                produto.Comissao = item.Comissao;
                produto.IdCateFk = item.IdCateFk;

                new ProdutoDAO().Update(produto);

                return Ok(produto);
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
                var produto = new ProdutoDAO().GetById(id);

                if (produto == null)
                {
                    return NotFound();
                }

                new ProdutoDAO().Delete(produto.Id);

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }
    }
}
