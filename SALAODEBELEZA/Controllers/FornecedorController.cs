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

        [HttpGet("Vizualizar")]
        public ActionResult GetFornecedor()
        {
            try
            {
                var listaFornecedores = new FornecedorDAO().List();
                return Ok(listaFornecedores);
            }
            catch (Exception ex)
            {
                return Problem("Erro ao listar os fornecedores: " + ex.Message);
            }

        }

        [HttpGet("Vizualizar por ID{id}")]

        public IActionResult GetById(int id)
        {
            try
            {
                var fornecedor = new FornecedorDAO().GetById(id);

                if (fornecedor == null)
                    return NotFound("Fornecedor não encontrado.");

                return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return Problem("Erro ao buscar o fornecedor: " + ex.Message);
            }
        }

        [HttpPost("Cadastrar Fornecedor")]
        public IActionResult Post([FromBody] FornecedorDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var fornecedor = new Fornecedor
                {
                    NomeFantasia = dto.NomeFantasia,
                    RazaoSocial = dto.RazaoSocial,
                    Cnpj = dto.Cnpj,
                    Site = dto.Site,
                    IdEndFk = dto.IdEndFk
                };

                fornecedor.Id = new FornecedorDAO().Insert(fornecedor);

                return Created("", fornecedor);
            }
            catch (Exception ex)
            {
                return Problem("Erro ao criar o fornecedor: " + ex.Message);
            }
        }


        [HttpPut("Atualizar Fornecedor{id}")]
        public IActionResult Put(int id, [FromBody] FornecedorDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var fornecedorExistente = new FornecedorDAO().GetById(id);

                if (fornecedorExistente == null)
                    return NotFound("Fornecedor não encontrado.");

                fornecedorExistente.NomeFantasia = dto.NomeFantasia;
                fornecedorExistente.RazaoSocial = dto.RazaoSocial;
                fornecedorExistente.Cnpj = dto.Cnpj;
                fornecedorExistente.Site = dto.Site;
                fornecedorExistente.IdEndFk = dto.IdEndFk;

                new FornecedorDAO().Update(fornecedorExistente);

                return Ok(fornecedorExistente);
            }
            catch (Exception ex)
            {
                return Problem("Erro ao atualizar o fornecedor: " + ex.Message);
            }
        }

        [HttpDelete("Deletar Fornecedor{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var fornecedorExistente = new FornecedorDAO().GetById(id);

                if (fornecedorExistente == null)
                    return NotFound("Fornecedor não encontrado.");

                new FornecedorDAO().Delete(id);

                return Ok("Fornecedor excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return Problem("Erro ao excluir o fornecedor: " + ex.Message);
            }
        }
    }
}

