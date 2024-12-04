using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("profissional")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Profissional> listaProfissionais = new ProfissionalDAO().List();

            return Ok(listaProfissionais);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProfissionalDTO item)
        {
            var profissional = new Profissional
            {
                NomePro = item.NomePro,
                Celular = item.Celular,
                Email = item.Email,
                Cpf = item.Cpf,
                Sexo = item.Sexo,
                Observacoes = item.Observacoes,
                Expediente = item.Expediente,
                Possui_Agenda = item.Possui_Agenda,
                Ativo = item.Ativo,
                IdCateFk = item.IdCateFk,
                IdLogFk = item.IdLogFk,
                IdPerfFk = item.IdPerfFk,
                IdEndFk = item.IdEndFk
            };

            try
            {
                var dao = new ProfissionalDAO();
                profissional.Id = dao.Insert(profissional);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", profissional);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var profissional = new ProfissionalDAO().GetById(id);

                if (profissional == null)
                {
                    return NotFound();
                }

                return Ok(profissional);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProfissionalDTO item)
        {
            try
            {
                var profissional = new ProfissionalDAO().GetById(id);

                if (profissional == null)
                {
                    return NotFound();
                }

                profissional.NomePro = item.NomePro;
                profissional.Celular = item.Celular;
                profissional.Email = item.Email;
                profissional.Cpf = item.Cpf;
                profissional.Sexo = item.Sexo;
                profissional.Observacoes = item.Observacoes;
                profissional.Expediente = item.Expediente;
                profissional.Possui_Agenda = item.Possui_Agenda;
                profissional.Ativo = item.Ativo;
                profissional.IdCateFk = item.IdCateFk;
                profissional.IdLogFk = item.IdLogFk;
                profissional.IdPerfFk = item.IdPerfFk;
                profissional.IdEndFk = item.IdEndFk;

                new ProfissionalDAO().Update(profissional);

                return Ok(profissional);
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
                var profissional = new ProfissionalDAO().GetById(id);

                if (profissional == null)
                {
                    return NotFound();
                }

                new ProfissionalDAO().Delete(profissional.Id);

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }
    }
}
