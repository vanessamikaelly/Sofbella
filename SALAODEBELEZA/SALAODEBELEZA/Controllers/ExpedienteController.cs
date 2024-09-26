using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using System.Collections.Generic;
using System.Linq;

namespace SALAODEBELEZA.Controllers
{
    [Route("expediente")]
    [ApiController]
    public class ExpedienteController : ControllerBase
    {
        private static List<ExpedienteDTO> expedientes = new List<ExpedienteDTO>();

        [HttpGet]
        public ActionResult<IEnumerable<ExpedienteDTO>> Listar()
        {
            return Ok(expedientes);
        }

        [HttpGet("Buscar/id")]
        public ActionResult<ExpedienteDTO> BuscarPorId(int id)
        {
            var expediente = expedientes.FirstOrDefault(r => r.Id == id);
            if (expediente == null)
            {
                return NotFound();
            }
            return Ok(expediente);
        }

        [HttpPost("Criar")]
        public ActionResult Criar([FromBody] ExpedienteDTO expedienteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Todos os campos são obrigatórios.");
            }

            expedientes.Add(expedienteDTO);
            return CreatedAtAction(nameof(BuscarPorId), new { id = expedienteDTO.Id }, expedienteDTO);
        }

        [HttpPut("Atualizar/id")]
        public ActionResult Atualizar(int id, [FromBody] ExpedienteDTO expedienteAtualizado)
        {
            var expediente = expedientes.FirstOrDefault(r => r.Id == id);
            if (expediente == null)
            {
                return NotFound();
            }

            expediente.Dia = expedienteAtualizado.Dia;
            expediente.HoraEntrada = expedienteAtualizado.HoraEntrada;
            expediente.HoraInicioIntervalo = expedienteAtualizado.HoraInicioIntervalo;
            expediente.HoraFinalIntervalo = expedienteAtualizado.HoraFinalIntervalo;
            expediente.HoraSaida = expedienteAtualizado.HoraSaida;

            return NoContent();
        }


        [HttpDelete("Excluir/id")]
        public ActionResult Excluir(int id)
        {
            var expediente = expedientes.FirstOrDefault(r => r.Id == id);
            if (expediente == null)
            {
                return NotFound();
            }

           
            expedientes.Remove(expediente);
            return NoContent();
        }
    }
}
