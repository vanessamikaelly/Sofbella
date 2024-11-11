using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("perfil")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Perfil> listaPerfis = new PerfilDAO().List();

            return Ok(listaPerfis);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PerfilDTO item)
        {
            var perfil = new Perfil
            {
                Tipo_perfil = item.Tipo_perfil,
                Agenda = item.Agenda,
                Comissoes = item.Comissoes,
                Financeiro = item.Financeiro
            };

            try
            {
                var dao = new PerfilDAO();
                perfil.Id = dao.Insert(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", perfil);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var perfil = new PerfilDAO().GetById(id);

                if (perfil == null)
                {
                    return NotFound();
                }

                return Ok(perfil);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PerfilDTO item)
        {
            try
            {
                var perfil = new PerfilDAO().GetById(id);

                if (perfil == null)
                {
                    return NotFound();
                }

                perfil.Tipo_perfil = item.Tipo_perfil;
                perfil.Agenda = item.Agenda;
                perfil.Comissoes = item.Comissoes;
                perfil.Financeiro = item.Financeiro;

                new PerfilDAO().Update(perfil);

                return Ok(perfil);
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
                var perfil = new PerfilDAO().GetById(id);

                if (perfil == null)
                {
                    return NotFound();
                }

                new PerfilDAO().Delete(perfil.Id);

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }
    }
}
