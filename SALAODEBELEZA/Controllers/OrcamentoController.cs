using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("api/orcamento[controller]")]
    [ApiController]
    public class OrcamentoController: ControllerBase
    {
        private static List<Orcamento> listaorcamento = new List<Orcamento>();
        public OrcamentoController()
        {

        }

        [HttpGet("Vizualizar")]
        public ActionResult GetOrcamento()
        {
            return Ok(listaorcamento);

        }

        [HttpGet("Vizualizar por ID{id}")]

        public IActionResult GetById(int id)
        {
            var orcamento = listaorcamento.Where(item => item.Id == id).FirstOrDefault();

            return Ok(orcamento);
        }

        [HttpPost("Cadastrar")]
        public IActionResult Post([FromBody] OrcamentoDTO item)
        {
            var orcamento = new Orcamento();
            orcamento.Id = listaorcamento.Count + 1;
            orcamento.Descricao = item.Descricao;
            orcamento.Data = item.Data;
            orcamento.Validade = item.Validade;
            orcamento.Forma_Pagamento = item.Forma_Pagamento;
            orcamento.Observaçao = item.Observaçao;

            return Ok("Orcamento cadastrado com sucesso:" + item);
        }

        [HttpPut("Atualizar{id}")]
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

        [HttpDelete("Deletar{id}")]

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
