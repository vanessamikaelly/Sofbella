using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnamneseCapilarController : ControllerBase
    {
        public static List<AnamneseCapilar> listaAnamnese = new List<AnamneseCapilar>();
        public AnamneseCapilarController()
        {

        }

        [HttpGet]
        public ActionResult GetAnamnseCapilar()
        {
            return Ok(listaAnamnese);

        }

        [HttpGet("Buscar/id")]

        public IActionResult GetById(int id)
        {
            var anamnese = listaAnamnese.Where(item => item.Id == id).FirstOrDefault();

            return Ok(anamnese);
        }

        [HttpPut("Atualizar/id")]
        public IActionResult Put(int id, [FromBody] AnamneseCapilarDTO item)
        {
            var anamnese = listaAnamnese.Where(item => item.Id == id).FirstOrDefault();

            if (anamnese == null)
            {
                return NotFound();
            }

            anamnese.TipoCabelo = item.TipoCabelo;
            anamnese.Caracteristica = item.Caracteristica;
            anamnese.Comprimento = item.Comprimento;
            anamnese.Pigmentacao = item.Pigmentacao;
            anamnese.Elasticidade = item.Elasticidade;
            anamnese.Espessura = item.Espessura;
            anamnese.Volume = item.Volume;
            anamnese.Observacoes = item.Observacoes;
            anamnese.Resistencia = item.Resistencia;
            anamnese.Condicao = item.Condicao;
            anamnese.AntecedentesAlerg = item.AntecedentesAlerg;

            return Ok(listaAnamnese);
        }

        [HttpPost("Cadastrar/id")]
        public IActionResult Post([FromBody] AnamneseCapilarDTO item)
        {
            var anamnese = new AnamneseCapilar();
            anamnese.Id = listaAnamnese.Count + 1;
            anamnese.TipoCabelo = item.TipoCabelo;
            anamnese.Caracteristica = item.Caracteristica;
            anamnese.Comprimento = item.Comprimento;
            anamnese.Pigmentacao = item.Pigmentacao;
            anamnese.Elasticidade = item.Elasticidade;
            anamnese.Espessura = item.Espessura;
            anamnese.Volume = item.Volume;
            anamnese.Observacoes = item.Observacoes;
            anamnese.Resistencia = item.Resistencia;
            anamnese.Condicao = item.Condicao;
            anamnese.AntecedentesAlerg = item.AntecedentesAlerg;

            return Ok("Categoria cadastrada com sucesso:" + item);
        }

        [HttpDelete("Excluir/id")]

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
