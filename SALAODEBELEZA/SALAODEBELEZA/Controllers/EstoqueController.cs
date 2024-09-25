using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("api/estoque[controller]")]
    [ApiController]
    public class EstoqueController: ControllerBase
    {
        private static List<Estoque> listaestoque = new List<Estoque>();
        public EstoqueController()
        {

        }

        [HttpGet]
        public ActionResult GetEstoque()
        {
            return Ok(listaestoque);

        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var estoque = listaestoque.Where(item => item.Id == id).FirstOrDefault();

            return Ok(estoque);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrcamentoDTO item)
        {
            var estoque = listaestoque.Where(item => item.Id == id).FirstOrDefault();

            if (estoque == null)
            {
                return NotFound();
            }

            return Ok(listaestoque);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var estoque = listaestoque.Where(item => item.Id == id).FirstOrDefault();

            if (estoque == null)
            {
                return NotFound();
            }

            listaestoque.Remove(estoque);

            return Ok(estoque);
        }
    }
}
