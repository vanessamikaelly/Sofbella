using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("Anamnese-manicure-pedicure")]
    [ApiController]
    public class AnamneseManicureEPedicureController : ControllerBase
    {
        private static List<AnamneseManicureEPedicureDTO> anamneses = new List<AnamneseManicureEPedicureDTO>();

        [HttpGet]
        public ActionResult<IEnumerable<AnamneseManicureEPedicureDTO>> Listar()
        {
            return Ok(anamneses);
        }

        [HttpGet("Buscar/id")]
        public ActionResult<AnamneseManicureEPedicureDTO> BuscarPorId(int id)
        {
            var anamnese = anamneses.FirstOrDefault(a => a.Id == id);
            if (anamnese == null)
            {
                return NotFound();
            }
            return Ok(anamnese);
        }

        [HttpPost("Criar")]
        public ActionResult Criar([FromBody] AnamneseManicureEPedicureDTO anamneseDTO)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(anamneseDTO.DescricaoAlergia))
            {
                return BadRequest("Todos os campos são obrigatórios.");
            }

            anamneses.Add(anamneseDTO);
            return CreatedAtAction(nameof(BuscarPorId), new { id = anamneseDTO.Id }, anamneseDTO);
        }

        [HttpPut("Atualizar/id")]
        public ActionResult Atualizar(int id, [FromBody] AnamneseManicureEPedicureDTO anamneseAtualizada)
        {
            var anamnese = anamneses.FirstOrDefault(a => a.Id == id);
            if (anamnese == null)
            {
                return NotFound();
            }

            anamnese.Frequenca = anamneseAtualizada.Frequenca;
            anamnese.RetiraCuticula = anamneseAtualizada.RetiraCuticula;
            anamnese.RoeUnhas = anamneseAtualizada.RoeUnhas;
            anamnese.Alergia = anamneseAtualizada.Alergia;
            anamnese.DescricaoAlergia = anamneseAtualizada.DescricaoAlergia;
            anamnese.FormatoPreferencia = anamneseAtualizada.FormatoPreferencia;
            anamnese.TonalidadePreferida = anamneseAtualizada.TonalidadePreferida;
            anamnese.UnhaEncravada = anamneseAtualizada.UnhaEncravada;
            anamnese.TeveOnocomicose = anamneseAtualizada.TeveOnocomicose;

            return NoContent();
        }

      
        [HttpDelete("Excluir/id")]
        public ActionResult Excluir(int id)
        {
            var anamnese = anamneses.FirstOrDefault(a => a.Id == id);
            if (anamnese == null)
            {
                return NotFound();
            }

            
            anamneses.Remove(anamnese);
            return NoContent();
        }
    }
}
