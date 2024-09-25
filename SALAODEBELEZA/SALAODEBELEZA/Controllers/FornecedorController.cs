using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("api/fornecedor[controller]")]
    [ApiController]
    public class FornecedorController: ControllerBase
    {
        private static List<Fornecedor> listafornecedor = new List<Fornecedor>();
        public FornecedorController()
        {

        }

        [HttpGet]
        public ActionResult GetFornecedor()
        {
            return Ok(listafornecedor);

        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var fornecedor = listafornecedor.Where(item => item.Id == id).FirstOrDefault();

            return Ok(fornecedor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] FornecedorDTO item)
        {
            var fornecedor = listafornecedor.Where(item => item.Id == id).FirstOrDefault();

            if (fornecedor == null)
            {
                return NotFound();
            }

            fornecedor.Empresa = item.Empresa;
            fornecedor.Site = item.Site;
     
            return Ok(listafornecedor);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var fornecedor = listafornecedor.Where(item => item.Id == id).FirstOrDefault();

            if (fornecedor == null)
            {
                return NotFound();
            }

            listafornecedor.Remove(fornecedor);

            return Ok(fornecedor);
        }
    }
}
