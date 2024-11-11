using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarioController : ControllerBase
    {
        private static List<Calendario> listaCalendario = new List<Calendario>();

        public CalendarioController()
        {

        }

        [HttpGet]
        public ActionResult GetCalendario()
        {
            return Ok(listaCalendario);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string Servico)
        {
            var calendario = listaCalendario.Where(item => item.Servico == Servico).FirstOrDefault();

            return Ok(calendario);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CalendarioDTO item)
        {
            var calendario = listaCalendario.Where(item => item.Id == id).FirstOrDefault();

            if (calendario == null)
            {
                return NotFound();
            }

            calendario.Cliente = item.Cliente;
            calendario.Data = item.Data;
            calendario.Hora = item.Hora;

            return Ok(listaCalendario);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var calendario = listaCalendario.Where(item => item.Id == id).FirstOrDefault();

            if (calendario == null)
            {
                return NotFound();
            }

            listaCalendario.Remove(calendario);

            return Ok(calendario);
        }
    }
}

