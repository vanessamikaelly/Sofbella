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
                var listaEnderecos = new EnderecoDAO().List();
                return Ok(listaEnderecos);
            }
            catch (Exception ex)
            {
                return Problem("Erro ao listar os endereços: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var endereco = new EnderecoDAO().GetById(id);

                if (endereco == null)
                    return NotFound("Endereço não encontrado.");

                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return Problem("Erro ao buscar o endereço: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] EnderecoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var endereco = new Endereco
                {
                    Rua = dto.Rua,
                    Bairro = dto.Bairro,
                    Numero = dto.Numero,
                    Cidade = dto.Cidade,
                    Estado = dto.Estado,
                    Pais = dto.Pais,
                    CEP = dto.CEP
                };

                endereco.Id = new EnderecoDAO().Insert(endereco);

                return Created("", endereco);
            }
            catch (Exception ex)
            {
                return Problem("Erro ao criar o endereço: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EnderecoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var enderecoExistente = new EnderecoDAO().GetById(id);

                if (enderecoExistente == null)
                    return NotFound("Endereço não encontrado.");

                enderecoExistente.Rua = dto.Rua;
                enderecoExistente.Bairro = dto.Bairro;
                enderecoExistente.Numero = dto.Numero;
                enderecoExistente.Cidade = dto.Cidade;
                enderecoExistente.Estado = dto.Estado;
                enderecoExistente.Pais = dto.Pais;
                enderecoExistente.CEP = dto.CEP;

                new EnderecoDAO().Update(enderecoExistente);

                return Ok(enderecoExistente);
            }
            catch (Exception ex)
            {
                return Problem("Erro ao atualizar o endereço: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var enderecoExistente = new EnderecoDAO().GetById(id);

                if (enderecoExistente == null)
                    return NotFound("Endereço não encontrado.");

                new EnderecoDAO().Delete(id);

                return Ok("Endereço excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return Problem("Erro ao excluir o endereço: " + ex.Message);
            }
        }
    }
}
