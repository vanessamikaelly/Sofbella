using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.Models;


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

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var servico = listaservico.Where(item => item.Id == id).FirstOrDefault();

            return Ok(servico);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ServicoDTO item)
        {
            var servico = listaservico.Where(item => item.Id == id).FirstOrDefault();

            if (servico == null)
            {
                return NotFound();
            }

            servico.NomeServico = item.DataInicio;
            servico.Descricao = item.ValorInicial;
            servico.PrecoUnitario= item.PrecoUnitario;
            servico.DuracaoAtendimento= item.DuracaoAtendimento;
            servico.Comissao= item.Comissao;
            servico.Recorrencia= item.Recorrencia;
            servico.Categoria= item.Categoria;
            return Ok(listaservico);
        }

        [HttpDelete("{id}")]

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
