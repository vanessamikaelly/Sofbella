using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;
using System.Collections.Generic;

namespace SALAODEBELEZA.Controllers
{
    [Route("categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Categoria> listaCategorias = new CategoriaDAO().List();
            return Ok(listaCategorias);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoriaDTO item)
        {
            var categoria = new Categoria
            {
                Nome = item.Nome,
                Tipo = item.Tipo,
                Descricao = item.Descricao
            };

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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var categoria = new CategoriaDAO().GetById(id);

                if (categoria == null)
                {
                    return NotFound();
                }

                return Ok(categoria);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoriaDTO item)
        {
            try
            {
                var categoria = new CategoriaDAO().GetById(id);

                if (categoria == null)
                {
                    return NotFound();
                }

                categoria.Nome = item.Nome;
                categoria.Tipo = item.Tipo;
                categoria.Descricao = item.Descricao;

                new CategoriaDAO().Update(categoria);

                return Ok(categoria);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var categoria = new CategoriaDAO().GetById(id);

                if (categoria == null)
                {
                    return NotFound();
                }

                new CategoriaDAO().Delete(categoria.Id);

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }
    }
}
