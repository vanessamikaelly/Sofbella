/*using ApiTarefas2.Dtos;
using ApiTarefas2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefas2.Controllers
{
    [Route("tarefas")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Tarefa> listaTarefas = new TarefaDAO().List();

            return Ok(listaTarefas);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TarefaDTO item)
        {

            try
            {
                var categoria = new CategoriaDAO().GetById(item.Categoria);

                if(categoria == null ) 
                {
                    return NotFound($"Categoria {item.Categoria} não encontrado!");
                }


                var tarefa = new Tarefa();

                tarefa.Descricao = item.Descricao;
                tarefa.Feito = item.Feito;
                tarefa.Data = DateTime.Now;

                tarefa.Categoria = categoria;

                var dao = new TarefaDAO();
                tarefa.Id = dao.Insert(tarefa);

                return Created("", tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


           
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            try
            {
                var tarefa = new TarefaDAO().GetById(id);

                if (tarefa == null)
                {
                    return NotFound();
                }

                return Ok(tarefa);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TarefaDTO item)
        {
            try
            {
                var tarefa = new TarefaDAO().GetById(id);

                if (tarefa == null)
                {
                    return NotFound();
                }

                tarefa.Descricao = item.Descricao;
                tarefa.Feito = item.Feito;

                new TarefaDAO().Update(tarefa);

                return Ok(tarefa);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
                // return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var tarefa = new TarefaDAO().GetById(id);

                if (tarefa == null)
                {
                    return NotFound();
                }

                new TarefaDAO().Delete(tarefa.Id);

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

    }
}*/
