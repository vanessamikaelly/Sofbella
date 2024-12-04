using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;
using SOFBELLASALAOOO.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("api/estoque[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var listaEstoques = new EstoqueDAO().List();
                return Ok(listaEstoques);
            }
            catch (Exception ex)
            {
                return Problem("Erro ao listar os estoques: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var estoque = new EstoqueDAO().GetById(id);

                if (estoque == null)
                    return NotFound("Estoque não encontrado.");

                return Ok(estoque);
            }
            catch (Exception ex)
            {
                return Problem("Erro ao buscar o estoque: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] EstoqueDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var estoque = new Estoque
                {
                    NomeProduto = dto.NomeProduto,
                    EstoqueAtual = dto.EstoqueAtual,
                    Entrada = dto.Entrada,
                    PrecoCompra = dto.PrecoCompra,
                    PrecoVenda = dto.PrecoVenda,
                    IdFornFk = dto.IdFornFk,
                    IdProdFk = dto.IdProdFk
                };

                estoque.Id = new EstoqueDAO().Insert(estoque);

                return Created("", estoque);
            }
            catch (Exception ex)
            {
                return Problem("Erro ao criar o estoque: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EstoqueDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var estoqueExistente = new EstoqueDAO().GetById(id);

                if (estoqueExistente == null)
                    return NotFound("Estoque não encontrado.");

                estoqueExistente.NomeProduto = dto.NomeProduto;
                estoqueExistente.EstoqueAtual = dto.EstoqueAtual;
                estoqueExistente.Entrada = dto.Entrada;
                estoqueExistente.PrecoCompra = dto.PrecoCompra;
                estoqueExistente.PrecoVenda = dto.PrecoVenda;
                estoqueExistente.IdFornFk = dto.IdFornFk;
                estoqueExistente.IdProdFk = dto.IdProdFk;

                new EstoqueDAO().Update(estoqueExistente);

                return Ok(estoqueExistente);
            }
            catch (Exception ex)
            {
                return Problem("Erro ao atualizar o estoque: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var estoqueExistente = new EstoqueDAO().GetById(id);

                if (estoqueExistente == null)
                    return NotFound("Estoque não encontrado.");

                new EstoqueDAO().Delete(id);

                return Ok("Estoque excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return Problem("Erro ao excluir o estoque: " + ex.Message);
            }
        }
    }

}
