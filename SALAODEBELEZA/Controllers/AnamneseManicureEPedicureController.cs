using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("anamneseManicurePedicure")]
    [ApiController]
    public class AnamneseManicureEPedicureController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<AnamneseManicureEPedicure> listaAnamneses = new AnamneseManicureEPedicureDAO().List();

            return Ok(listaAnamneses);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AnamneseManicureEPedicureDTO item)
        {
            var anamnese = new AnamneseManicureEPedicure
            {
                Frequenca = item.Frequenca,
                RetiraCuticula = item.RetiraCuticula,
                RoeUnhas = item.RoeUnhas,
                Alergia = item.Alergia,
                DescricaoAlergia = item.DescricaoAlergia,
                FormatoPreferencia = item.FormatoPreferencia,
                TonalidadePreferida = item.TonalidadePreferida,
                UnhaEncravada = item.UnhaEncravada,
                Micose = item.Micose,
                CorEsmalte = item.CorEsmalte
            };

            try
            {
                var dao = new AnamneseManicureEPedicureDAO();
                anamnese.Id = dao.Insert(anamnese);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", anamnese);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var anamnese = new AnamneseManicureEPedicureDAO().GetById(id);

                if (anamnese == null)
                {
                    return NotFound();
                }

                return Ok(anamnese);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AnamneseManicureEPedicureDTO item)
        {
            try
            {
                var anamnese = new AnamneseManicureEPedicureDAO().GetById(id);

                if (anamnese == null)
                {
                    return NotFound();
                }

                anamnese.Frequenca = item.Frequenca;
                anamnese.RetiraCuticula = item.RetiraCuticula;
                anamnese.RoeUnhas = item.RoeUnhas;
                anamnese.Alergia = item.Alergia;
                anamnese.DescricaoAlergia = item.DescricaoAlergia;
                anamnese.FormatoPreferencia = item.FormatoPreferencia;
                anamnese.TonalidadePreferida = item.TonalidadePreferida;
                anamnese.UnhaEncravada = item.UnhaEncravada;
                anamnese.Micose = item.Micose;
                anamnese.CorEsmalte = item.CorEsmalte;

                new AnamneseManicureEPedicureDAO().Update(anamnese);

                return Ok(anamnese);
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
                var anamnese = new AnamneseManicureEPedicureDAO().GetById(id);

                if (anamnese == null)
                {
                    return NotFound();
                }

                new AnamneseManicureEPedicureDAO().Delete(anamnese.Id);

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }
    }
}
