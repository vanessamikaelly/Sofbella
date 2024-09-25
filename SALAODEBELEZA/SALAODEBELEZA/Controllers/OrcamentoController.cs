using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    public class OrcamentoController: ControllerBase
    {
        private static List<Orcamento> listaorcamento = new List<Orcamento>();
        public OrcamentoController()
        {

        }

        [HttpGet]
        public ActionResult GetOrcamento()
        {
            return Ok(listaorcamento);

        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var orcamento = listaorcamento.Where(item => item.Id == id).FirstOrDefault();

            return Ok(orcamento);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrcamentoDTO item)
        {
            var orcamento = listaorcamento.Where(item => item.Id == id).FirstOrDefault();

            if (orcamento == null)
            {
                return NotFound();
            }

            orcamento.Descricao = item.Descricao;
            orcamento.Data = item.Data;
            orcamento.Validade = item.Validade;
            orcamento.Forma_Pagamento = item.Forma_Pagamento;
            orcamento.Observaçao = item.Observaçao;

            return Ok(listaorcamento);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var orcamento = listaorcamento.Where(item => item.Id == id).FirstOrDefault();

            if (orcamento == null)
            {
                return NotFound();
            }

            listaorcamento.Remove(orcamento);

            return Ok(orcamento);
        }
    }
}
