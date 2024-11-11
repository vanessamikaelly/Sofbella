using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("api/pagamento[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private static List<Pagamento> listaPagamento = new List<Pagamento>();

        public PagamentoController()
        {

        }

        [HttpGet]
        public ActionResult GetPagamento()
        {
            return Ok(listaPagamento);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int FormaPagamento)
        {
            var pagamento = listaPagamento.Where(item => item.FormaPagamento == FormaPagamento).FirstOrDefault();

            return Ok(pagamento);
        }

        [HttpPut("{id}")] 
        public IActionResult Put(int id, [FromBody] PagamentoDTO item)
        {
            var pagamento = listaPagamento.Where(item => item.Id == id).FirstOrDefault();

            if (pagamento == null)
            {
                return NotFound();
            }

            pagamento.Valor = item.Valor;
            pagamento.RestaPagar = item.RestaPagar;
            pagamento.Desconto = item.Desconto;

            return Ok(listaPagamento);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pagamento = listaPagamento.Where(item => item.Id == id).FirstOrDefault();

            if (pagamento == null)
            {
                return NotFound();
            }

            listaPagamento.Remove(pagamento);

            return Ok(pagamento);
        }
    }
}

