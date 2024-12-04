using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.Models;
using SALAODEBELEZA.DTOS;


namespace SALAODEBELEZA.Controllers
{
    [Route("caixa")]
    [ApiController]
    public class CaixaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Caixa> listaCaixas = new CaixaDAO().List();
            return Ok(listaCaixas);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CaixaDTO item)
        {
            var caixa = new Caixa
            {
                UsuarioCaixa = item.UsuarioCaixa,
                DataInicio = item.DataInicio,
                ValorInicial = item.ValorInicial,
                EntradaCaixa = item.EntradaCaixa,
                SaidaCaixa = item.SaidaCaixa,
                SaldoFinal = item.SaldoFinal
            };

            try
            {
                var dao = new CaixaDAO();
                caixa.Id = dao.Insert(caixa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", caixa);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var caixa = new CaixaDAO().GetById(id);

                if (caixa == null)
                {
                    return NotFound();
                }

                return Ok(caixa);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CaixaDTO item)
        {
            try
            {
                var caixa = new CaixaDAO().GetById(id);

                if (caixa == null)
                {
                    return NotFound();
                }

                caixa.UsuarioCaixa = item.UsuarioCaixa;
                caixa.DataInicio = item.DataInicio;
                caixa.ValorInicial = item.ValorInicial;
                caixa.EntradaCaixa = item.EntradaCaixa;
                caixa.SaidaCaixa = item.SaidaCaixa;
                caixa.SaldoFinal = item.SaldoFinal;

                new CaixaDAO().Update(caixa);

                return Ok(caixa);
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
                var caixa = new CaixaDAO().GetById(id);

                if (caixa == null)
                {
                    return NotFound();
                }

                new CaixaDAO().Delete(caixa.Id);

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }
    }
}
