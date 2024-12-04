using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("anamneseCapilar")]
    [ApiController]
    public class AnamneseCapilarController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<AnamneseCapilar> listaAnamnesesCapilares = new AnamneseCapilarDAO().List();

            return Ok(listaAnamnesesCapilares);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AnamneseCapilarDTO item)
        {
            var anamneseCapilar = new AnamneseCapilar
            {
                TipoCabelo = item.TipoCabelo,
                Caracteristica = item.Caracteristica,
                Comprimento = item.Comprimento,
                Pigmentacao = item.Pigmentacao,
                Elasticidade = item.Elasticidade,
                Espessura = item.Espessura,
                Volume = item.Volume,
                Condicao = item.Condicao,
                Observacoes = item.Observacoes,
                AntecedentesAlerg = item.AntecedentesAlerg,
                Resistencia = item.Resistencia
            };

            try
            {
                var dao = new AnamneseCapilarDAO();
                anamneseCapilar.Id = dao.Insert(anamneseCapilar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", anamneseCapilar);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var anamneseCapilar = new AnamneseCapilarDAO().GetById(id);

                if (anamneseCapilar == null)
                {
                    return NotFound();
                }

                return Ok(anamneseCapilar);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AnamneseCapilarDTO item)
        {
            try
            {
                var anamneseCapilar = new AnamneseCapilarDAO().GetById(id);

                if (anamneseCapilar == null)
                {
                    return NotFound();
                }

                anamneseCapilar.TipoCabelo = item.TipoCabelo;
                anamneseCapilar.Caracteristica = item.Caracteristica;
                anamneseCapilar.Comprimento = item.Comprimento;
                anamneseCapilar.Pigmentacao = item.Pigmentacao;
                anamneseCapilar.Elasticidade = item.Elasticidade;
                anamneseCapilar.Espessura = item.Espessura;
                anamneseCapilar.Volume = item.Volume;
                anamneseCapilar.Condicao = item.Condicao;
                anamneseCapilar.Observacoes = item.Observacoes;
                anamneseCapilar.AntecedentesAlerg = item.AntecedentesAlerg;
                anamneseCapilar.Resistencia = item.Resistencia;

                new AnamneseCapilarDAO().Update(anamneseCapilar);

                return Ok(anamneseCapilar);
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
                var anamneseCapilar = new AnamneseCapilarDAO().GetById(id);

                if (anamneseCapilar == null)
                {
                    return NotFound();
                }

                new AnamneseCapilarDAO().Delete(anamneseCapilar.Id);

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }
    }
}
