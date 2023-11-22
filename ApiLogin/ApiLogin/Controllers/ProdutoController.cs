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
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ProdutoModel model,
            [FromServices] IProdutoRepository produtoRepository,
            IUsuarioRepository usuarioRepository)
        {
            try 
            {
                var email = User.Identity.Name; //email do usuário contido no TOKEN..
                var usuario = usuarioRepository.GetbyEmail(email);

                //criando um objeto da entidade produto..
                var produto = new Produto();
                produto.Nome = model.Nome;
                produto.Informacoes = model.Informacoes;
                produto.DataCadastro = DateTime.Now;               
                produto.IdUsuario = usuario.IdUsuario;
                produto.IdUsuario = usuario.IdUsuario;

                //gravando a produto no banco de dados..
                produtoRepository.Add(produto);

                return Ok("Produto cadastrada com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro:" + e.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUsaurio([FromServices] IProdutoRepository produtoRepository)
        {
            try
            {
                var email = User.Identity.Name;

                var produto = produtoRepository.(email);

                return Ok(new
                {
                    produto.IdProduto,
                    produto.Nome,
                    produto.Email,
                    produto.DataCadastro,
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro:" + e.Message);
            }
        }
    }
}
