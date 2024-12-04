using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;
using SOFBELLASALAOOO.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("api/pagamento[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var listaPagamentos = new PagamentoDAO().List();
                return Ok(listaPagamentos);
            }
            catch (Exception ex)
            {
                return Problem("Erro ao listar os pagamentos: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var pagamento = new PagamentoDAO().GetById(id);

                if (pagamento == null)
                    return NotFound("Pagamento não encontrado.");

                return Ok(pagamento);
            }
            catch (Exception ex)
            {
                return Problem("Erro ao buscar o pagamento: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] PagamentoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var pagamento = new Pagamento
                {
                    DataPagamento = dto.DataPagamento,
                    Valor = dto.Valor,
                    Desconto = dto.Desconto,
                    FormaPagamento = dto.FormaPagamento,
                    IdCaiFk = dto.IdCaiFk,
                    IdServFk = dto.IdServFk,
                    IdOrcaFk = dto.IdOrcaFk,
                    IdCliFk = dto.IdCliFk
                };

                pagamento.Id = new PagamentoDAO().Insert(pagamento);

                return Created("", pagamento);
            }
            catch (Exception ex)
            {
                return Problem("Erro ao criar o pagamento: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PagamentoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var pagamentoExistente = new PagamentoDAO().GetById(id);

                if (pagamentoExistente == null)
                    return NotFound("Pagamento não encontrado.");

                pagamentoExistente.DataPagamento = dto.DataPagamento;
                pagamentoExistente.Valor = dto.Valor;
                pagamentoExistente.Desconto = dto.Desconto;
                pagamentoExistente.FormaPagamento = dto.FormaPagamento;
                pagamentoExistente.IdCaiFk = dto.IdCaiFk;
                pagamentoExistente.IdServFk = dto.IdServFk;
                pagamentoExistente.IdOrcaFk = dto.IdOrcaFk;
                pagamentoExistente.IdCliFk = dto.IdCliFk;

                new PagamentoDAO().Update(pagamentoExistente);

                return Ok(pagamentoExistente);
            }
            catch (Exception ex)
            {
                return Problem("Erro ao atualizar o pagamento: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var pagamentoExistente = new PagamentoDAO().GetById(id);

                if (pagamentoExistente == null)
                    return NotFound("Pagamento não encontrado.");

                new PagamentoDAO().Delete(id);

                return Ok("Pagamento excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return Problem("Erro ao excluir o pagamento: " + ex.Message);
            }
        }
    }
}
