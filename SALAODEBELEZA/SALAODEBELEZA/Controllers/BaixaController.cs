using Microsoft.AspNetCore.Mvc;
using SOFBELLASALAOOO.DTO;
using System.Collections.Generic;
using System.Linq;

namespace SOFBELLASALAOOO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaixaController : ControllerBase
    {
        private static List<BaixaDTO> listaBaixa = new List<BaixaDTO>();

        [HttpGet]
        public ActionResult<List<BaixaDTO>> GetBaixas()
        {
            return Ok(listaBaixa);
        }

        [HttpGet("{id}")]
        public IActionResult GetBaixaById(int id)
        {
            var baixa = listaBaixa.ElementAtOrDefault(id);
            if (baixa == null)
            {
                return NotFound();
            }
            return Ok(baixa);
        }

        [HttpPost]
        public IActionResult CreateBaixa([FromBody] BaixaDTO baixaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            listaBaixa.Add(baixaDTO);

            return CreatedAtAction(nameof(GetBaixaById), new { id = listaBaixa.Count - 1 }, baixaDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBaixa(int id, [FromBody] BaixaDTO baixaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var baixa = listaBaixa.ElementAtOrDefault(id);
            if (baixa == null)
            {
                return NotFound();
            }

            
            baixa.Descricao = baixaDTO.Descricao;
            baixa.Servico = baixaDTO.Servico;
            baixa.ConfirmarQuantidadeAoFinalizar = baixaDTO.ConfirmarQuantidadeAoFinalizar;
            baixa.PermitirAlterarProduto = baixaDTO.PermitirAlterarProduto;

            return Ok(baixa);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBaixa(int id)
        {
            var baixa = listaBaixa.ElementAtOrDefault(id);
            if (baixa == null)
            {
                return NotFound();
            }

            listaBaixa.RemoveAt(id);

            return Ok(baixa);
        }

        public class BaixaDTO
        {
            internal object Descricao;
            internal object Servico;
            internal object ConfirmarQuantidadeAoFinalizar;
            internal object PermitirAlterarProduto;
        }
    }
}
