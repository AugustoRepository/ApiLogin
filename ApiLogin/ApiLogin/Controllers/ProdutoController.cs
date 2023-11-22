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
            [FromServices] IProdutoRepository produtoRepository)
        {
            try
            {
                if (produtoRepository.GetbyEmail(model.Email) != null)
                {
                    return StatusCode(500, "Erro, o email informado ja encontra-se cadastrado.");
                }
                else 
                {
                    var produto = new Produto();
                    produto.Nome = model.Nome;
                    produto.Email = model.Email;
                    produto.Senha = model.Senha;
                    produto.DataCadastro = DateTime.Now;

                    produtoRepository.Add(produto);

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
        public IActionResult GetUsaurio([FromServices] IProdutoRepository produtoRepository)
        {
            try
            {
                var email = User.Identity.Name;

                var produto = produtoRepository.GetbyEmail(email);

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
