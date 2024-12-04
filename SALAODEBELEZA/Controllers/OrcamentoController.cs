using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("api/orcamento[controller]")]
    [ApiController]
    public class OrcamentoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var listaOrcamentos = new OrcamentoDAO().List();
                return Ok(listaOrcamentos);
            }
            catch (Exception ex)
            {
                return Problem("Erro ao listar os orçamentos: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var orcamento = new OrcamentoDAO().GetById(id);

                if (orcamento == null)
                    return NotFound("Orçamento não encontrado.");

                return Ok(orcamento);
            }
            catch (Exception ex)
            {
                return Problem("Erro ao buscar o orçamento: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrcamentoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var orcamento = new Orcamento
                {
                    Descricao = dto.Descricao,
                    Data = dto.Data,
                    Forma_Pagamento = dto.Forma_Pagamento,
                    Valor = dto.Valor,
                    IdServFk = dto.IdServFk
                };

                orcamento.Id = new OrcamentoDAO().Insert(orcamento);

                return Created("", orcamento);
            }
            catch (Exception ex)
            {
                return Problem("Erro ao criar o orçamento: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrcamentoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var orcamentoExistente = new OrcamentoDAO().GetById(id);

                if (orcamentoExistente == null)
                    return NotFound("Orçamento não encontrado.");

                orcamentoExistente.Descricao = dto.Descricao;
                orcamentoExistente.Data = dto.Data;
                orcamentoExistente.Forma_Pagamento = dto.Forma_Pagamento;
                orcamentoExistente.Valor = dto.Valor;
                orcamentoExistente.IdServFk = dto.IdServFk;

                new OrcamentoDAO().Update(orcamentoExistente);

                return Ok(orcamentoExistente);
            }
            catch (Exception ex)
            {
                return Problem("Erro ao atualizar o orçamento: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var orcamentoExistente = new OrcamentoDAO().GetById(id);

                if (orcamentoExistente == null)
                    return NotFound("Orçamento não encontrado.");

                new OrcamentoDAO().Delete(id);

                return Ok("Orçamento excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return Problem("Erro ao excluir o orçamento: " + ex.Message);
            }
        }
    }
}
