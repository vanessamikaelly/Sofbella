using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaixaInternaController : ControllerBase
    {

        private static List<BaixaInterna> baixasInternas = new List<BaixaInterna>();
        public BaixaInternaController()
        {
            if (baixasInternas.Count == 0)
            {
                baixasInternas.Add(new BaixaInterna
                {
                    Descricao = "Produto 1",
                    Estoque_atual = 100
                });

                baixasInternas.Add(new BaixaInterna
                {
                    Descricao = "Produto 2",
                    Estoque_atual = 50
                });
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] BaixaInterna baixaInterna)
        {
            if (baixaInterna == null)
            {
                return BadRequest("Dados inválidos.");
            }

            baixasInternas.Add(baixaInterna);
            return StatusCode(StatusCodes.Status201Created, baixaInterna);
        }
        [HttpGet]
        public IActionResult GetBaixasInternas()
        {
            return Ok(baixasInternas);
        }
        [HttpGet("{descricao}")]
        public IActionResult GetBaixaInterna(string descricao)
        {
            var baixaInterna = baixasInternas.FirstOrDefault(b => b.Descricao == descricao);
            if (baixaInterna == null)
            {
                return NotFound("Baixa interna não encontrada.");
            }
            return Ok(baixaInterna);
        }
        [HttpPut("{descricao}")]
        public IActionResult Put(string descricao, [FromBody] BaixaInterna baixaInternaAtualizada)
        {
            var baixaInterna = baixasInternas.FirstOrDefault(b => b.Descricao == descricao);
            if (baixaInterna == null)
            {
                return NotFound("Baixa interna não encontrada.");
            }

            baixaInterna.Estoque_atual = baixaInternaAtualizada.Estoque_atual;
            return Ok(baixaInterna);
        }
        [HttpDelete("{descricao}")]
        public IActionResult Delete(string descricao)
        {
            var baixaInterna = baixasInternas.FirstOrDefault(b => b.Descricao == descricao);
            if (baixaInterna == null)
            {
                return NotFound("Baixa interna não encontrada.");
            }

            baixasInternas.Remove(baixaInterna);
            return Ok("Baixa interna deletada com sucesso!");
        }
    }
}

