using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("endereco")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Endereco> listaEnderecos = new EnderecoDAO().List();
                return Ok(listaEnderecos);
            }
            catch (Exception)
            {
                return Problem("Ocorreu um erro ao processar a solicitação.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] EnderecoDTO item)
        {
            var endereco = new Endereco
            {
                Rua = item.Rua,
                Bairro = item.Bairro,
                Numero = item.Numero,
                Cidade = item.Cidade,
                Estado = item.Estado,
                Pais = item.Pais,
                CEP = item.CEP
            };

            try
            {
                var dao = new EnderecoDAO();
                endereco.Id = dao.Insert(endereco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", endereco);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var endereco = new EnderecoDAO().GetById(id);

                if (endereco == null)
                {
                    return NotFound();
                }

                return Ok(endereco);
            }
            catch (Exception)
            {
                return Problem("Ocorreu um erro ao processar a solicitação.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EnderecoDTO item)
        {
            try
            {
                var endereco = new EnderecoDAO().GetById(id);

                if (endereco == null)
                {
                    return NotFound();
                }

                endereco.Rua = item.Rua;
                endereco.Bairro = item.Bairro;
                endereco.Numero = item.Numero;
                endereco.Cidade = item.Cidade;
                endereco.Estado = item.Estado;
                endereco.Pais = item.Pais;
                endereco.CEP = item.CEP;

                new EnderecoDAO().Update(endereco);

                return Ok(endereco);
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
                var endereco = new EnderecoDAO().GetById(id);

                if (endereco == null)
                {
                    return NotFound();
                }

                new EnderecoDAO().Delete(endereco.Id);

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Ocorreu um erro ao processar a solicitação.");
            }
        }
    }
}
