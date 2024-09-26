using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;

namespace SALAODEBELEZA.Controllers
{
    [Route("Anamnese-corporal")]
    [ApiController]
    public class AnamneseCorporalController : ControllerBase
    {
        private static List<AnamneseCorporalDTO> anamneses = new List<AnamneseCorporalDTO>();

        // Listar todas as anamneses
        [HttpGet]
        public ActionResult<IEnumerable<AnamneseCorporalDTO>> Listar()
        {
            return Ok(anamneses);
        }

        // Buscar anamnese por ID
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

        // Criar uma nova anamnese
        [HttpPost("Criar")]
        public ActionResult Criar([FromBody] AnamneseCorporalDTO anamneseDTO)
        {
            // Validar se todos os campos obrigatórios foram preenchidos
            if (!ModelState.IsValid || string.IsNullOrEmpty(anamneseDTO.TipoAlergia))
            {
                return BadRequest("Todos os campos são obrigatórios.");
            }

            // Adicionar a nova anamnese à lista
            anamneses.Add(anamneseDTO);
            return CreatedAtAction(nameof(BuscarPorId), new { id = anamneseDTO.Id }, anamneseDTO);
        }

        // Atualizar anamnese existente
        [HttpPut("Atualizar/id")]
        public ActionResult Atualizar(int id, [FromBody] AnamneseCorporalDTO anamneseAtualizada)
        {
            var anamnese = anamneses.FirstOrDefault(a => a.Id == id);
            if (anamnese == null)
            {
                return NotFound();
            }

            // Atualizar os campos da anamnese
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

        // Excluir anamnese por ID
        [HttpDelete("Excluir/id")]
        public ActionResult Excluir(int id)
        {
            var anamnese = anamneses.FirstOrDefault(a => a.Id == id);
            if (anamnese == null)
            {
                return NotFound();
            }

            // Remover a anamnese da lista
            anamneses.Remove(anamnese);
            return NoContent();
        }
    }
}
