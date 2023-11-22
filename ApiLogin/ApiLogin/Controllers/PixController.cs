using ApiLogin.Presentation.Model;
using ApiLogin.Repository.Contracts;
using ApiLogin.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ApiLogin.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PixController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(PixModel model,
            [FromServices] IPixRepository pixRepository,
            [FromServices] IUsuarioRepository usuarioRepository)
        {
            try 
            {
                var email = User.Identity.Name; //email do usuário contido no TOKEN..
                var usuario = usuarioRepository.GetbyEmail(email);

                //criando um objeto da entidade pix..
                var pix = new Pix();
                pix.ChavePix = model.ChavePix;
                pix.Valor = model.Valor;
                pix.DataTransacao = DateTime.Now;
                pix.IdUsuario = usuario.IdUsuario;
             

                //gravando a pix no banco de dados..
                pixRepository.Add(pix);

                return Ok("Pix cadastrada com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro:" + e.Message);
            }
        }


        [HttpGet]
        public IActionResult GetAll(
       [FromServices] IPixRepository pixRepository,
       [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var email = User.Identity.Name;
                var usuario = usuarioRepository.GetbyEmail(email);

                var lista = new List<PixConsultaModel>();

                foreach (var item in pixRepository.GetAll())
                {
                    var model = new PixConsultaModel();
                    model.Id = item.IdPix;
                    model.ChavePix = item.ChavePix;
                    model.Valor = item.Valor;
                    model.DataTransacao = item.DataTransacao;
                   


                    lista.Add(model);
                }

                return Ok(lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id,
           [FromServices] IPixRepository pixRepository,
           [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var email = User.Identity.Name;
                var usuario = usuarioRepository.GetbyEmail(email);

                var produto = pixRepository.Get(id);

                if (produto != null)
                {
                    var model = new PixConsultaModel();
                    model.Id = produto.IdPix;
                    model.ChavePix = produto.ChavePix;
                    model.Valor = produto.Valor;
                    model.DataTransacao = produto.DataTransacao;

                    return Ok(model);
                }
                else
                {
                    return StatusCode(500, "Produto não encontrada.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

    }
}
