using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private static List<Categoria> listacategoria = new List<Categoria>();
        public CategoriaController()
        {

        }

        [HttpGet]
        public ActionResult GetFornecedor()
        {
            return Ok(listacategoria);

        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var categoria = listacategoria.Where(item => item.Id == id).FirstOrDefault();

            return Ok(categoria);
        }

        [HttpPost("Cadastrar")]
        public IActionResult Post([FromBody] CategoriaDTO item)
        {
            var categoria = new Categoria();
            categoria.Id = listacategoria.Count + 1;
            categoria.Nome = item.Nome;
            categoria.Tipo = item.Tipo;
            categoria.Ativo = item.Ativo;

            return Ok("Categoria cadastrada com sucesso:" + item);
        }

        [HttpPut("Atualozar{id}")]
        public IActionResult Put(int id, [FromBody] CategoriaDTO item)
        {
            var categoria = listacategoria.Where(item => item.Id == id).FirstOrDefault();

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.Nome = item.Nome;
            categoria.Tipo = item.Tipo;
            categoria.Ativo = item.Ativo;

            return Ok(listacategoria);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var categoria = listacategoria.Where(item => item.Id == id).FirstOrDefault();

            if (categoria == null)
            {
                return NotFound();
            }

            listacategoria.Remove(categoria);

            return Ok(categoria);
        }
    }
}
