using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace WebApplication1.Controllers
{
    [Route("agenda")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Agenda> listaAgendas = new AgendaDAO().List(); 

            return Ok(listaAgendas);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AgendaDTO item)
        {
            var agenda = new Agenda
            {
                Data = item.Data,
                Telefone = item.Telefone,
                NomeCliente = item.NomeCliente,
                Observacoes = item.Observacoes,
                Responsavel = item.Responsavel,
                Hora = item.Hora,
                TempoAtendimento = item.TempoAtendimento,
                Servico = item.Servico,
                IdProFk = item.IdProFk,
                IdCliFk = item.IdCliFk
            };

            try
            {
                var dao = new AgendaDAO();
                agenda.Id = dao.Insert(agenda); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", agenda);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var agenda = new AgendaDAO().GetById(id); 

                if (agenda == null)
                {
                    return NotFound();
                }

                return Ok(agenda);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AgendaDTO item)
        {
            try
            {
                var agenda = new AgendaDAO().GetById(id); 

                if (agenda == null)
                {
                    return NotFound();
                }

                agenda.Data = item.Data;
                agenda.Telefone = item.Telefone;
                agenda.NomeCliente = item.NomeCliente;
                agenda.Observacoes = item.Observacoes;
                agenda.Responsavel = item.Responsavel;
                agenda.Hora = item.Hora;
                agenda.TempoAtendimento = item.TempoAtendimento;
                agenda.Servico = item.Servico;
                agenda.IdProFk = item.IdProFk;
                agenda.IdCliFk = item.IdCliFk;

                new AgendaDAO().Update(agenda); 

                return Ok(agenda);
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
                var agenda = new AgendaDAO().GetById(id); 

                if (agenda == null)
                {
                    return NotFound();
                }

                new AgendaDAO().Delete(agenda.Id); 

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }
    }
}

