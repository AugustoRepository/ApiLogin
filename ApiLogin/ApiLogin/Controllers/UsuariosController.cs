using ApiLogin.Presentation.Model;
using ApiLogin.Repository.Contracts;
using ApiLogin.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiLogin.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(UsuarioCadastroModel model,
            [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                if (usuarioRepository.GetbyEmail(model.Email) != null)
                {
                    return StatusCode(500, "Erro, o email informado ja encontra-se cadastrado.");
                }
                else 
                {
                    var usuario = new Usuario();
                    usuario.Nome = model.Nome;
                    usuario.Email = model.Email;
                    usuario.Senha = model.Senha;
                    usuario.DataCadastro = DateTime.Now;
                    usuario.IdPerfil = int.Parse(model.IdPerfil);

                    usuarioRepository.Add(usuario);

                    return Ok("Usaurio cadastrado com sucesso.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro:" + e.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUsaurio([FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var email = User.Identity.Name;

                var usuario = usuarioRepository.GetbyEmail(email);

                return Ok(new
                {
                    usuario.IdUsuario,
                    usuario.Nome,
                    usuario.Email,
                    usuario.DataCadastro,
                    usuario.IdPerfil,
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro:" + e.Message);
            }
        }
    }
}
