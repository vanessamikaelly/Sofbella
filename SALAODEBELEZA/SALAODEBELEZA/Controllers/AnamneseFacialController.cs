using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("anamneseFacial")]
    [ApiController]
    public class AnamneseFacialController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<AnamneseFacial> listaAnamneses = new AnamneseFacialDAO().List();

            return Ok(listaAnamneses);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AnamneseFacialDTO item)
        {
            var anamnese = new AnamneseFacial
            {
                Gestante = item.Gestante,
                Queda_Cabelo = item.Queda_Cabelo,
                Alergia = item.Alergia,
                Medicacao = item.Medicacao,
                TipodePele = item.TipodePele
            };

            try
            {
                var dao = new AnamneseFacialDAO();
                anamnese.Id = dao.Insert(anamnese);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", anamnese);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var anamnese = new AnamneseFacialDAO().GetById(id);

                if (anamnese == null)
                {
                    return NotFound();
                }

                return Ok(anamnese);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AnamneseFacialDTO item)
        {
            try
            {
                var anamnese = new AnamneseFacialDAO().GetById(id);

                if (anamnese == null)
                {
                    return NotFound();
                }

                anamnese.Gestante = item.Gestante;
                anamnese.Queda_Cabelo = item.Queda_Cabelo;
                anamnese.Alergia = item.Alergia;
                anamnese.Medicacao = item.Medicacao;
                anamnese.TipodePele = item.TipodePele;

                new AnamneseFacialDAO().Update(anamnese);

                return Ok(anamnese);
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
                var anamnese = new AnamneseFacialDAO().GetById(id);

                if (anamnese == null)
                {
                    return NotFound();
                }

                new AnamneseFacialDAO().Delete(anamnese.Id);

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }
    }
}
