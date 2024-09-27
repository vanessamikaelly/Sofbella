using Microsoft.AspNetCore.Mvc;
using SOFBELLASALAOOO.DTO;
using SOFBELLASALAOOO.Models;
using System.Collections.Generic;
using System.Linq;

namespace SOFBELLASALAOOO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private static List<Comanda> listaComandas = new List<Comanda>();
        private static List<Cliente> listaClientes = new List<Cliente>
        {
            new Cliente(1, "Cliente 1"),
            new Cliente(2, "Cliente 2")
        };

        [HttpGet]
        public ActionResult<List<Comanda>> GetComandas()
        {
            return Ok(listaComandas);
        }

        [HttpGet("{id}")]
        public IActionResult GetComandaById(int id)
        {
            var comanda = listaComandas.ElementAtOrDefault(id);
            if (comanda == null)
            {
                return NotFound();
            }
            return Ok(comanda);
        }

        [HttpPost]
        public IActionResult CreateComanda([FromBody] ComandaDTO comandaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cliente = listaClientes.FirstOrDefault(c => c.Id == comandaDTO.ClienteId);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            var novaComanda = new Comanda(
                comandaDTO.Data,
                cliente,
                comandaDTO.Email,
                comandaDTO.CPF,
                comandaDTO.Telefone
            );

            listaComandas.Add(novaComanda);

            return CreatedAtAction(nameof(GetComandaById), new { id = listaComandas.Count - 1 }, novaComanda);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateComanda(int id, [FromBody] ComandaDTO comandaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comandaExistente = listaComandas.ElementAtOrDefault(id);
            if (comandaExistente == null)
            {
                return NotFound();
            }

            var cliente = listaClientes.FirstOrDefault(c => c.Id == comandaDTO.ClienteId);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            comandaExistente.Data = comandaDTO.Data;
            comandaExistente.Cliente = cliente;
            comandaExistente.Email = comandaDTO.Email;
            comandaExistente.CPF = comandaDTO.CPF;
            comandaExistente.Telefone = comandaDTO.Telefone;

            return Ok(comandaExistente);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComanda(int id)
        {
            var comanda = listaComandas.ElementAtOrDefault(id);
            if (comanda == null)
            {
                return NotFound();
            }

            listaComandas.RemoveAt(id);

            return Ok(comanda);
        }
    }
}
