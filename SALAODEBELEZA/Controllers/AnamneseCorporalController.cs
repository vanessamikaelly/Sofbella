using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;
using System.Collections.Generic;

namespace SALAODEBELEZA.Controllers
{
    [Route("anamneseCorporal")]
    [ApiController]
    public class AnamneseCorporalController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<AnamneseCorporal>> GetAll()
        {
            try
            {
                var lista = new AnamneseCorporalDAO1().List();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error while listing: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<AnamneseCorporal> GetById(int id)
        {
            try
            {
                var anamnese = new AnamneseCorporalDAO1().GetById(id);

                if (anamnese == null)
                {
                    return NotFound();
                }

                return Ok(anamnese);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error while getting by ID: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] AnamneseCorporalDTO anamneseDTO)
        {
            try
            {
                if (!ModelState.IsValid || string.IsNullOrEmpty(anamneseDTO.TipoAlergia))
                {
                    return BadRequest("All fields are required.");
                }

                var anamnese = new AnamneseCorporal
                {
                    Depilacao = anamneseDTO.Depilacao,
                    Alergia = anamneseDTO.Alergia,
                    TipoAlergia = anamneseDTO.TipoAlergia,
                    ProblemaPele = anamneseDTO.ProblemaPele,
                    TratamentoDermatologico = anamneseDTO.TratamentoDermatologico,
                    Gestante = anamneseDTO.Gestante,
                    TipoPele = anamneseDTO.TipoPele,
                    VasosVarizes = anamneseDTO.VasosVarizes,
                    MetodosUtilizados = anamneseDTO.MetodosUtilizados,
                    Areas = anamneseDTO.Areas
                };

                anamnese.Id = new AnamneseCorporalDAO1().Insert(anamnese);

                return CreatedAtAction(nameof(GetById), new { id = anamnese.Id }, anamneseDTO);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error while creating: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] AnamneseCorporalDTO updatedAnamnese)
        {
            try
            {
                var existingAnamnese = new AnamneseCorporalDAO1().GetById(id);

                if (existingAnamnese == null)
                {
                    return NotFound();
                }

                existingAnamnese.Depilacao = updatedAnamnese.Depilacao;
                existingAnamnese.Alergia = updatedAnamnese.Alergia;
                existingAnamnese.TipoAlergia = updatedAnamnese.TipoAlergia;
                existingAnamnese.ProblemaPele = updatedAnamnese.ProblemaPele;
                existingAnamnese.TratamentoDermatologico = updatedAnamnese.TratamentoDermatologico;
                existingAnamnese.Gestante = updatedAnamnese.Gestante;
                existingAnamnese.TipoPele = updatedAnamnese.TipoPele;
                existingAnamnese.VasosVarizes = updatedAnamnese.VasosVarizes;
                existingAnamnese.MetodosUtilizados = updatedAnamnese.MetodosUtilizados;
                existingAnamnese.Areas = updatedAnamnese.Areas;

                new AnamneseCorporalDAO1().Update(existingAnamnese);

                return NoContent();
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error while updating: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var anamnese = new AnamneseCorporalDAO1().GetById(id);

                if (anamnese == null)
                {
                    return NotFound();
                }

                new AnamneseCorporalDAO1().Delete(id);

                return NoContent();
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error while deleting: {ex.Message}");
            }
        }
    }
}
