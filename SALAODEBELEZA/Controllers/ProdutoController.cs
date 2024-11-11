using Microsoft.AspNetCore.Mvc;
using SOFBELLASALAOOO.DTO;
using SOFBELLASALAOOO.DTOS;
using SOFBELLASALAOOO.Models;
using System.Collections.Generic;
using System.Linq;

namespace SOFBELLASALAOOO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private static List<Produto> listaProdutos = new List<Produto>();

        [HttpGet]
        public ActionResult<List<Produto>> GetProdutos()
        {
            return Ok(listaProdutos);
        }

        [HttpGet("{id}")]
        public IActionResult GetProdutoById(int id)
        {
            var produto = listaProdutos.ElementAtOrDefault(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult CreateProduto([FromBody] ProdutoDTO produtoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            var novoProduto = new Produto(
                produtoDTO.Nome,
                produtoDTO.Unidade,
                produtoDTO.Descricao,
                produtoDTO.CodigoBarras,
                produtoDTO.Categoria,
                produtoDTO.Preco,
                produtoDTO.PrecoCusto,
                produtoDTO.Comissao
            );

            
            listaProdutos.Add(novoProduto);

            return CreatedAtAction(nameof(GetProdutoById), new { id = listaProdutos.Count - 1 }, novoProduto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduto(int id, [FromBody] ProdutoDTO produtoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produtoExistente = listaProdutos.ElementAtOrDefault(id);
            if (produtoExistente == null)
            {
                return NotFound();
            }

            produtoExistente.Nome = produtoDTO.Nome;
            produtoExistente.Unidade = produtoDTO.Unidade;
            produtoExistente.Descricao = produtoDTO.Descricao;
            produtoExistente.CodigoBarras = produtoDTO.CodigoBarras;
            produtoExistente.Categoria = produtoDTO.Categoria;
            produtoExistente.Preco = produtoDTO.Preco;
            produtoExistente.PrecoCusto = produtoDTO.PrecoCusto;
            produtoExistente.Comissao = produtoDTO.Comissao;

            return Ok(produtoExistente);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(int id)
        {
            var produto = listaProdutos.ElementAtOrDefault(id);
            if (produto == null)
            {
                return NotFound();
            }

            listaProdutos.RemoveAt(id);

            return Ok(produto);
        }
    }
}
