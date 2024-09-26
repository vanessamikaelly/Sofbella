using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    { 
        private static List<Perfil> perfis = new List<Perfil>();
        public PerfilController()
        {
            if (perfis.Count == 0)
            {
                perfis.Add(new Perfil
                {
                    Id = 1,
                    Tipo_perfil = "Administrador",
                    Agenda = "Sim",
                    Comissoes = "Sim",
                    Financeiro = "Sim"
                });

                perfis.Add(new Perfil
                {
                    Id = 2,
                    Tipo_perfil = "Funcionário",
                    Agenda = "Sim",
                    Comissoes = "Sim",
                    Financeiro = "Não"
                });
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] Perfil perfil)
        {
            if (perfil == null)
            {
                return BadRequest("Perfil inválido.");
            }

            perfil.Id = perfis.Count + 1;
            perfis.Add(perfil);
            return StatusCode(StatusCodes.Status201Created, perfil);
        }
        [HttpGet]
        public IActionResult GetPerfis()
        {
            return Ok(perfis);
        }
        [HttpGet("{id}")]
        public IActionResult GetPerfil(int id)
        {
            var perfil = perfis.FirstOrDefault(p => p.Id == id);
            if (perfil == null)
            {
                return NotFound("Perfil não encontrado.");
            }
            return Ok(perfil);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Perfil perfilAtualizado)
        {
            var perfil = perfis.FirstOrDefault(p => p.Id == id);
            if (perfil == null)
            {
                return NotFound("Perfil não encontrado.");
            }

            perfil.Tipo_perfil = perfilAtualizado.Tipo_perfil;
            perfil.Agenda = perfilAtualizado.Agenda;
            perfil.Comissoes = perfilAtualizado.Comissoes;
            perfil.Financeiro = perfilAtualizado.Financeiro;

            return Ok(perfil);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var perfil = perfis.FirstOrDefault(p => p.Id == id);
            if (perfil == null)
            {
                return NotFound("Perfil não encontrado.");
            }

            perfis.Remove(perfil);
            return Ok("Perfil deletado com sucesso!");
        }
    }
}

