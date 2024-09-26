using Microsoft.AspNetCore.Mvc;
using SALAODEBELEZA.Models; 

namespace SALAODEBELEZA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private static List<Login> logins = new List<Login>();

        public LoginController()
        {
            if (logins.Count == 0)
            { 
                logins.Add(new Login { Email = "usuario@exemplo.com", Senha = "senha123" });
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] Login login)
        {
            if (login == null)
            {
                return BadRequest("Dados de login inválidos.");
            }

            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Senha))
            {
                return BadRequest("Email e senha são obrigatórios.");
            }

            logins.Add(login);
            return StatusCode(StatusCodes.Status201Created, login);
        }
        [HttpGet("{email}")]
        public IActionResult Get(string email)
        {
            var login = logins.FirstOrDefault(l => l.Email == email);
            if (login == null)
            {
                return NotFound("Login não encontrado.");
            }
            return Ok(login);
        }
        [HttpPut("{email}")]
        public IActionResult Put(string email, [FromBody] Login loginAtualizado)
        {
            var login = logins.FirstOrDefault(l => l.Email == email);
            if (login == null)
            {
                return NotFound("Login não encontrado.");
            }

            login.Senha = loginAtualizado.Senha; 

            return Ok(login);
        }
        [HttpDelete("{email}")]
        public IActionResult Delete(string email)
        {
            var login = logins.FirstOrDefault(l => l.Email == email);
            if (login == null)
            {
                return NotFound("Login não encontrado.");
            }

            logins.Remove(login);
            return Ok("Login deletado com sucesso!");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(logins);
        }
    }
}

