using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using SOFBELLASALAOOO.Models;
using SOFBELLASALAOOO.DTO;

namespace SOFBELLASALAOOO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloqueioController : ControllerBase
    {
        private static BloqueioDAO bloqueioDAO = new BloqueioDAO();

        
        [HttpGet]
        public ActionResult<List<Bloqueio>> GetBloqueio()
        {
            try
            {
                var bloqueios = bloqueioDAO.List();
                return Ok(bloqueios);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao listar bloqueios: " + ex.Message);
            }
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var bloqueio = bloqueioDAO.GetById(id);

                if (bloqueio == null)
                {
                    return NotFound();
                }

                return Ok(bloqueio);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar bloqueio: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] BloqueioDTO item)
        {
            var bloqueio = new Bloqueio
            {
                Profissional = item.Profissional,
                DataInicio = item.DataInicio,
                HoraInicio = item.HoraInicio,
                DataFinal = item.DataFinal,
                HoraFinal = item.HoraFinal,
                Motivo = item.Motivo,
                DiaInteiro = item.DiaInteiro
            };

            try
            {
                var dao = new BloqueioDAO();
                bloqueio.Id = dao.Insert(bloqueio);  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", bloqueio);  
        }



      
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Bloqueio item)
        {
            try
            {
                
                var bloqueio = bloqueioDAO.GetById(id);

                
                if (bloqueio == null)
                {
                    return NotFound();
                }

                
                bloqueio.Profissional = item.Profissional;
                bloqueio.DataInicio = item.DataInicio;
                bloqueio.HoraInicio = item.HoraInicio;
                bloqueio.DataFinal = item.DataFinal;
                bloqueio.HoraFinal = item.HoraFinal;
                bloqueio.Motivo = item.Motivo;
                bloqueio.DiaInteiro = item.DiaInteiro;

                
                bloqueioDAO.Update(bloqueio);

                return Ok(bloqueio);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao atualizar bloqueio: " + ex.Message);
            }
        }

       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var bloqueio = bloqueioDAO.GetById(id);

                if (bloqueio == null)
                {
                    return NotFound();
                }

                bloqueioDAO.Delete(id);

                return Ok(bloqueio);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao excluir bloqueio: " + ex.Message);
            }
        }
    }
}
