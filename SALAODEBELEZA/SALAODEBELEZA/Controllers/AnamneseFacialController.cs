using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;

namespace SALAODEBELEZA.Controllers
{
   
    

        [Route("Anamnese-facial")]
        [ApiController]
        public class AnamneseFacialController : ControllerBase
        {
            private static List<AnamneseFacialDTO> anamneses = new List<AnamneseFacialDTO>();

            [HttpGet]
            public ActionResult<IEnumerable<AnamneseFacialDTO>> Listar()
            {
                return Ok(anamneses);
            }

            [HttpGet("Buscar/id")]
            public ActionResult<AnamneseFacialDTO> BuscarPorId(int id)
            {
                var anamnese = anamneses.FirstOrDefault(a => a.Id == id);
                if (anamnese == null)
                {
                    return NotFound();
                }
                return Ok(anamnese);
            }

            [HttpPost("Criar")]
            public ActionResult Criar([FromBody] AnamneseFacialDTO anamneseDTO)
            {
              
                if (!ModelState.IsValid || string.IsNullOrEmpty(anamneseDTO.Alergia))
                {
                    return BadRequest("Todos os campos são obrigatórios.");
                }

              
                anamneses.Add(anamneseDTO);
                return CreatedAtAction(nameof(BuscarPorId), new { id = anamneseDTO.Id }, anamneseDTO);
            }

          
            [HttpPut("Atualizar/id")]
            public ActionResult Atualizar(int id, [FromBody] AnamneseFacialDTO anamneseAtualizada)
            {
                var anamnese = anamneses.FirstOrDefault(a => a.Id == id);
                if (anamnese == null)
                {
                    return NotFound();
                }

              
                anamnese.Gestante = anamneseAtualizada.Gestante;
                anamnese.Queda_Cabelo = anamneseAtualizada.Queda_Cabelo;
                anamnese.Alergia = anamneseAtualizada.Alergia;
                anamnese.Medicacao = anamneseAtualizada.Medicacao;

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



