using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.Models;
using SALAODEBELEZA.DTOS;


namespace SALAODEBELEZA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaixaController : ControllerBase
    {
        public static List<Caixa> listacaixa = new List<Caixa>();
        public CaixaController()
        {

        }

        [HttpGet]
        public ActionResult GetCaixa()
        {
            return Ok(listacaixa);

        }

        [HttpGet("Buscar/id")]

        public IActionResult GetById(int id)
        {
            var caixa = listacaixa.Where(item => item.Id == id).FirstOrDefault();

            return Ok(caixa);
        }

        [HttpPut("Atualizar/id")]
        public IActionResult Put(int id, [FromBody] CaixaDTO item)
        {
            var caixa = listacaixa.Where(item => item.Id == id).FirstOrDefault();

            if (caixa == null)
            {
                return NotFound();
            }

            caixa.DataInicio = item.DataInicio;
            caixa.UsuarioCaixa = item.UsuarioCaixa;
            caixa.ValorInicial = item.ValorInicial;
            caixa.EntradaCaixa = item.EntradaCaixa;
            caixa.SaidaCaixa = item.SaidaCaixa;
            caixa.SaldoFinal = item.SaldoFinal;

            return Ok(listacaixa);
        }

        [HttpPost("Cadastrar/id")]
        public IActionResult Post([FromBody] CaixaDTO item)
        {
            var caixa = new Caixa();
            caixa.Id = listacaixa.Count + 1;
            caixa.UsuarioCaixa = item.UsuarioCaixa;
            caixa.DataInicio = item.DataInicio;
            caixa.ValorInicial = item.ValorInicial;
            caixa.EntradaCaixa = item.EntradaCaixa;
            caixa.SaidaCaixa = item.SaidaCaixa;
            caixa.SaldoFinal = item.SaldoFinal;


            return Ok("Categoria cadastrada com sucesso:" + item);
        }

        [HttpDelete("Excluir/id")]

        public IActionResult Delete(int id)
        {
            var caixa = listacaixa.Where(item => item.Id == id).FirstOrDefault();

            if (caixa == null)
            {
                return NotFound();
            }

            listacaixa.Remove(caixa);

            return Ok(caixa);
        }
    }
}
