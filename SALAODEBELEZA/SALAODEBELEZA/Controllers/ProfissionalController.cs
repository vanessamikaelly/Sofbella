using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
   

        public class ProfissionalController : ControllerBase
        {
            private static List<Profissional> listaProfissional = new List<Profissional>();

            public ProfissionalController()
            {

            }

            [HttpGet]
            public ActionResult GetProfissional()
            {
                return Ok(listaProfissional);
            }


            [HttpGet("{id}")]

            public IActionResult GetById(string Name)
            {
                var profissional = listaProfissional.Where(item => item.Name == Name).FirstOrDefault();

                return Ok(profissional);
            }
            public IActionResult GetBy(string Name, string Observacoes)
            {
                var profissional = listaProfissional.Where(item => item.Observacoes == Observacoes).FirstOrDefault();

                return Ok(profissional);
            }

            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] ProfissionalDTO item)
            {
                var profissional = listaProfissional.Where(item => item.Id == id).FirstOrDefault();

                if (profissional == null)
                {
                    return NotFound();
                }

                profissional.Ativo = item.Ativo;
                profissional.Expediente = item.Expediente;
                profissional.Agenda = item.Agenda;

                return Ok(listaProfissional);
            }
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var profissional = listaProfissional.Where(item => item.Id == id).FirstOrDefault();

                if (profissional == null)
                {
                    return NotFound();
                }

                listaProfissional.Remove(profissional);

                return Ok(profissional);
            }
        }
}
