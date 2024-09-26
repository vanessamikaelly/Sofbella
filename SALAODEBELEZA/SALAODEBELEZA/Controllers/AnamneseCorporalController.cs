using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;

namespace SALAODEBELEZA.Controllers
{
    [Route("Anamnese-corporal")]
    [ApiController]
    public class AnamneseCorporalController : ControllerBase
    {
        private static List<AnamneseCorporalDTO> anamneses = new List<AnamneseCorporalDTO>();

       
        [HttpGet]
        public ActionResult<IEnumerable<AnamneseCorporalDTO>> Listar()
        {
            return Ok(anamneses);
        }

      
        [HttpGet("Buscar/id")]
        public ActionResult<AnamneseCorporalDTO> BuscarPorId(int id)
        {
            var anamnese = anamneses.FirstOrDefault(a => a.Id == id);
            if (anamnese == null)
            {
                return NotFound();
            }
            return Ok(anamnese);
        }

    
        [HttpPost("Criar")]
        public ActionResult Criar([FromBody] AnamneseCorporalDTO anamneseDTO)
        {
           
            if (!ModelState.IsValid || string.IsNullOrEmpty(anamneseDTO.TipoAlergia))
            {
                return BadRequest("Todos os campos são obrigatórios.");
            }

           
            anamneses.Add(anamneseDTO);
            return CreatedAtAction(nameof(BuscarPorId), new { id = anamneseDTO.Id }, anamneseDTO);
        }

     
        [HttpPut("Atualizar/id")]
        public ActionResult Atualizar(int id, [FromBody] AnamneseCorporalDTO anamneseAtualizada)
        {
            var anamnese = anamneses.FirstOrDefault(a => a.Id == id);
            if (anamnese == null)
            {
                return NotFound();
            }

          
            anamnese.Depilacao = anamneseAtualizada.Depilacao;
            anamnese.Alergia = anamneseAtualizada.Alergia;
            anamnese.TipoAlergia = anamneseAtualizada.TipoAlergia;
            anamnese.ProblemaPele = anamneseAtualizada.ProblemaPele;
            anamnese.TratamentoDermatologico = anamneseAtualizada.TratamentoDermatologico;
            anamnese.Gestante = anamneseAtualizada.Gestante;
            anamnese.TipoPele = anamneseAtualizada.TipoPele;
            anamnese.VasosVarizes = anamneseAtualizada.VasosVarizes;
            anamnese.MetodosUtilizados = anamneseAtualizada.MetodosUtilizados;
            anamnese.Areas = anamneseAtualizada.Areas;

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
