using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;
using System.Net;

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

        [HttpGet("Vizualizar")]
        public ActionResult GetFornecedor()
        {
            return Ok(listafornecedor);

        }

        [HttpGet("Vizualizar por ID{id}")]

        public IActionResult GetById(int id)
        {
            var fornecedor = listafornecedor.Where(item => item.Id == id).FirstOrDefault();

            return Ok(fornecedor);
        }

        [HttpPost("Cadastrar")]
        public IActionResult Post([FromBody] FornecedorDTO item)
        {
            var fornecedor = new Fornecedor();
            fornecedor.Id = listafornecedor.Count + 1;
            fornecedor.Site = item.Site;
            fornecedor.Empresa = item.Empresa;

            return Ok("Fornecedor cadastrado com sucesso:" + item);
        }

        [HttpPut("Atualizar{id}")]
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

        [HttpDelete("Deletar{id}")]

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
