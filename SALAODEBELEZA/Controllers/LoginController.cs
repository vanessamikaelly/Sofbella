using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.DTOS;
using SALAODEBELEZA.Models;

namespace SALAODEBELEZA.Controllers
{
    [Route("login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Login> listaLogins = new LoginDAO().List();

            return Ok(listaLogins);
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoginDTO item)
        {
            var login = new Login
            {
                Email = item.Email,
                Senha = item.Senha
            };

            try
            {
                var dao = new LoginDAO();
                login.Id = dao.Insert(login);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", login);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var login = new LoginDAO().GetById(id);

                if (login == null)
                {
                    return NotFound();
                }

                return Ok(login);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LoginDTO item)
        {
            try
            {
                var login = new LoginDAO().GetById(id);

                if (login == null)
                {
                    return NotFound();
                }

                login.Email = item.Email;
                login.Senha = item.Senha;

                new LoginDAO().Update(login);

                return Ok(login);
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
                var login = new LoginDAO().GetById(id);

                if (login == null)
                {
                    return NotFound();
                }

                new LoginDAO().Delete(login.Id);

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }
    }
}
