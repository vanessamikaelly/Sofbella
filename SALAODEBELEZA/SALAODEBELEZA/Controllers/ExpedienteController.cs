using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("expediente")]
    [ApiController]
    public class ExpedienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Expediente> listaExpedientes = new ExpedienteDAO().List();

            return Ok(listaExpedientes);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ExpedienteDTO item)
        {
            var expediente = new Expediente
            {
                Nome = item.Nome,
                Dia = item.Dia,
                HoraEntrada = item.HoraEntrada,
                AlmoçoInicio = item.AlmoçoInicio,
                AlmoçoFinal = item.AlmoçoFinal,
                IntervaloAlmoço = item.IntervaloAlmoço,
                HoraSaida = item.HoraSaida,
                FuncionarioIdFK = item.FuncionarioIdFK
            };

            try
            {
                var dao = new ExpedienteDAO();
                expediente.Id = dao.Insert(expediente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", expediente);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var expediente = new ExpedienteDAO().GetById(id);

                if (expediente == null)
                {
                    return NotFound();
                }

                return Ok(expediente);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ExpedienteDTO item)
        {
            try
            {
                var expediente = new ExpedienteDAO().GetById(id);

                if (expediente == null)
                {
                    return NotFound();
                }

                expediente.Nome = item.Nome;
                expediente.Dia = item.Dia;
                expediente.HoraEntrada = item.HoraEntrada;
                expediente.AlmoçoInicio = item.AlmoçoInicio;
                expediente.AlmoçoFinal = item.AlmoçoFinal;
                expediente.IntervaloAlmoço = item.IntervaloAlmoço;
                expediente.HoraSaida = item.HoraSaida;
                expediente.FuncionarioIdFK = item.FuncionarioIdFK;

                new ExpedienteDAO().Update(expediente);

                return Ok(expediente);
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
                var expediente = new ExpedienteDAO().GetById(id);

                if (expediente == null)
                {
                    return NotFound();
                }

                new ExpedienteDAO().Delete(expediente.Id);

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }
    }
}
