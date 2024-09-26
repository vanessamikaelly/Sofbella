using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.Models;


namespace SALAODEBELEZA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnamneseCapilarController : ControllerBase
    {
        public static List<AnamneseCapilar> listaAnamnese = new List<listaAnamnese>();
        public AnamneseCapilarController()
        {

        }

        [HttpGet]
        public ActionResult GetAnamnseCapilar()
        {
            return Ok(listaAnamnese);

        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var anamnese = listaAnamnese.Where(item => item.Id == id).FirstOrDefault();

            return Ok(anamnese);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AnamneseCapilarDTO item)
        {
            var anamnese = listaAnamnese.Where(item => item.Id == id).FirstOrDefault();

            if (anamnese == null)
            {
                return NotFound();
            }

            anamnese.TipoCabelo = item.TipoCabelo;
            anamnese.Caracteristicas = item.Caracteristicas;
            anamnese.Comprimento= item.Comprimento;
            anamnese.Pigmento = item.Pigmento;
            anamnese.Elasticidade = item.Elasticidade;
            anamnese.Espessura = item.Espessura;
            anamnese.Volume = item.Volume;
            anamnese.Observacoes = item.Observacoes;
            anamnese.Resistencia = item.Resistencia;
            anamnese.Condicao = item.Condicao;
            anamnese.AntecedentesAlerg = item.AntecedentesAlerg;

            return Ok(listaAnamnese);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var anamnese = listaAnamnese.Where(item => item.Id == id).FirstOrDefault();

            if (anamnese == null)
            {
                return NotFound();
            }

            listaAnamnese.Remove(anamnese);

            return Ok(anamnese);
        }
    }
}
