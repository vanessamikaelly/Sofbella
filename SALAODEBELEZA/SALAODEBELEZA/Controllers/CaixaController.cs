using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.Models;


namespace SALAODEBELEZA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaixaController : ControllerBase
    {
        public static List<Caixa> listacaixa = new List<Caixa>();
        public CaixaController()
        {

        }

        [HttpGet]
        public ActionResult GetCaixa()
        {
            return Ok(listacaixa);

        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var caixa = listacaixa.Where(item => item.Id == id).FirstOrDefault();

            return Ok(caixa);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CaixaDTO item)
        {
            var caixa = listacategoria.Where(item => item.Id == id).FirstOrDefault();

            if (caixa == null)
            {
                return NotFound();
            }

            caixa.DataInicio = item.DataInicio;
            caixa.ValorInicial = item.ValorInicial;

            return Ok(listacaixa);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var caixa = listacaixa.Where(item => item.Id == id).FirstOrDefault();

            if (caixa == null)
            {
                return NotFound();
            }

            listacaixa.Remove(caixa);

            return Ok(caixa);
        }
    }
}
