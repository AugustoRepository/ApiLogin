using ApiLogin.Presentation.Authorization;
using ApiLogin.Presentation.Model;
using ApiLogin.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiLogin.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult GenerateToken(LoginModel model,
            [FromServices]IUsuarioRepository usuarioRepository,
            [FromServices] JwtConfiguration jwtConfiguration)
        {
            try
            {
                if (usuarioRepository.GetByEmailAndSenha(model.Email, model.Senha) != null )
                {
                    return Ok(new { accessToken = jwtConfiguration.GenerateToken(model.Email) });
                }
                else
                {
                    return StatusCode(500, "Acesso negado. Usuario nao encontrado");
                }
            }
            catch (Exception e)
            {
               return StatusCode(500, "Ocorreu um Erro" + e);
            }   
        }
    }
}
