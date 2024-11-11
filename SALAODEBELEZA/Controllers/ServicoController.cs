using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.Models;
using SALAODEBELEZA.DTOS;

namespace SALAODEBELEZA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        public static List<Servico> listaservico = new List<Servico>();
        public ServicoController()
        {

        }

        [HttpGet]
        public ActionResult GetServico()
        {
            return Ok(listaservico);

        }

        [HttpGet("Buscar/id")]

        public IActionResult GetById(int id)
        {
            var servico = listaservico.Where(item => item.Id == id).FirstOrDefault();

            return Ok(servico);
        }

        [HttpPut("Atuaizar/id")]
        public IActionResult Put(int id, [FromBody] ServicoDTO item)
        {
            var servico = listaservico.Where(item => item.Id == id).FirstOrDefault();

            if (servico == null)
            {
                return NotFound();
            }

            servico.NomeServico = item.NomeServico;
            servico.Descricao = item.Descricao;
            servico.PrecoUnitario = item.PrecoUnitario;
            servico.DuracaoAtendimento = item.DuracaoAtendimento;
            servico.Comissao = item.Comissao;
            return Ok(listaservico);
        }

        [HttpPost("Cadastrar/id")]
        public IActionResult Post([FromBody] ServicoDTO item)
        {
            var servico = new Servico();
            servico.Id = listaservico.Count + 1;
            servico.NomeServico = item.NomeServico;
            servico.Descricao = item.Descricao;
            servico.PrecoUnitario = item.PrecoUnitario;
            servico.DuracaoAtendimento = item.DuracaoAtendimento;
            servico.Comissao = item.Comissao;
            return Ok("Categoria cadastrada com sucesso:" + item);
        }

        [HttpDelete("Excluir/id")]

        public IActionResult Delete(int id)
        {
            var servico = listaservico.Where(item => item.Id == id).FirstOrDefault();

            if (servico == null)
            {
                return NotFound();
            }

            listaservico.Remove(servico);

            return Ok(servico);
        }
    }
}
