/*using ApiTarefas2.Dtos;
using ApiTarefas2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace ApiTarefas2.Controllers
{
    [Route("categorias")]
    [ApiController]
    public class CategoriaController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var categorias = new CategoriaDAO().List();

            return Ok(categorias);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoriaDTO item)
        {
            var categoria = new Categoria();

            categoria.Nome = item.Nome;

            try
            {
                var dao = new CategoriaDAO();
                categoria.Id = dao.Insert(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Created("", categoria);
        }
    }
}*/
