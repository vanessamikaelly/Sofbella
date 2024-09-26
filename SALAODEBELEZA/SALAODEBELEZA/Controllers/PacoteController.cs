using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.Models; 

namespace SALAODEBELEZA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacotesController : ControllerBase
    {
        private static List<Pacote> pacotes = new List<Pacote>();

        public PacotesController()
        {
            if (pacotes.Count == 0)
            {
                pacotes.Add(new Pacote
                {
                    Nome = "Pacote Básico",
                    Unidade = 1,
                    Descricao = "Descrição do pacote básico",
                    Codigo_barras = "1234567890123",
                    Categoria = "Serviço",
                    Preco = 100.0,
                    Comissao = 10.0
                });
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] Pacote pacote)
        {
            if (pacote == null)
            {
                return BadRequest("Dados do pacote inválidos.");
            }

            if (string.IsNullOrWhiteSpace(pacote.Nome) || pacote.Preco < 0 || pacote.Unidade < 0)
            {
                return BadRequest("Nome, preço e unidade são obrigatórios.");
            }

            pacotes.Add(pacote);
            return StatusCode(StatusCodes.Status201Created, pacote);
        }
        [HttpGet("{codigoBarras}")]
        public IActionResult Get(string codigoBarras)
        {
            var pacote = pacotes.FirstOrDefault(p => p.Codigo_barras == codigoBarras);
            if (pacote == null)
            {
                return NotFound("Pacote não encontrado.");
            }
            return Ok(pacote);
        }
        [HttpPut("{codigoBarras}")]
        public IActionResult Put(string codigoBarras, [FromBody] Pacote pacoteAtualizado)
        {
            var pacote = pacotes.FirstOrDefault(p => p.Codigo_barras == codigoBarras);
            if (pacote == null)
            {
                return NotFound("Pacote não encontrado.");
            }

            pacote.Nome = pacoteAtualizado.Nome;
            pacote.Unidade = pacoteAtualizado.Unidade;
            pacote.Descricao = pacoteAtualizado.Descricao;
            pacote.Categoria = pacoteAtualizado.Categoria;
            pacote.Preco = pacoteAtualizado.Preco;
            pacote.Comissao = pacoteAtualizado.Comissao;

            return Ok(pacote);
        }
        [HttpDelete("{codigoBarras}")]
        public IActionResult Delete(string codigoBarras)
        {
            var pacote = pacotes.FirstOrDefault(p => p.Codigo_barras == codigoBarras);
            if (pacote == null)
            {
                return NotFound("Pacote não encontrado.");
            }

            pacotes.Remove(pacote);
            return Ok("Pacote deletado com sucesso!");
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(pacotes);
        }
    }
}

