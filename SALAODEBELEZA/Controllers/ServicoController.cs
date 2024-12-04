using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.Models;
using SALAODEBELEZA.DTOS;

namespace SALAODEBELEZA.Controllers
{
    [Route("servico")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Servico> listaServicos = new ServicoDAO().List();
            return Ok(listaServicos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ServicoDTO item)
        {
            var servico = new Servico
            {
                NomeServico = item.NomeServico,
                Descricao = item.Descricao,
                Valor = item.Valor,
                DuracaoAtendimento = item.DuracaoAtendimento,
                Comissao = item.Comissao,
                IdCateFk = item.IdCateFk
            };

            try
            {
                var dao = new ServicoDAO();
                servico.Id = dao.Insert(servico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", servico);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var servico = new ServicoDAO().GetById(id);

                if (servico == null)
                {
                    return NotFound();
                }

                return Ok(servico);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ServicoDTO item)
        {
            try
            {
                var servico = new ServicoDAO().GetById(id);

                if (servico == null)
                {
                    return NotFound();
                }

                servico.NomeServico = item.NomeServico;
                servico.Descricao = item.Descricao;
                servico.Valor = item.Valor;
                servico.DuracaoAtendimento = item.DuracaoAtendimento;
                servico.Comissao = item.Comissao;
                servico.IdCateFk = item.IdCateFk;

                new ServicoDAO().Update(servico);

                return Ok(servico);
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
                var servico = new ServicoDAO().GetById(id);

                if (servico == null)
                {
                    return NotFound();
                }

                new ServicoDAO().Delete(servico.Id);

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }
    }
}
