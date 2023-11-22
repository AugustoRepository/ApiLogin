using ApiLogin.Presentation.Model;
using ApiLogin.Repository.Contracts;
using ApiLogin.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiLogin.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ProdutoModel model,
            [FromServices] IProdutoRepository produtoRepository,
            [FromServices] IUsuarioRepository usuarioRepository)
        {
            try 
            {
                var email = User.Identity.Name; //email do usuário contido no TOKEN..
                var usuario = usuarioRepository.GetbyEmail(email);

                //criando um objeto da entidade produto..
                var produto = new Produto();
                produto.Nome = model.Nome;
                produto.Preco = model.Preco;
                produto.Quantidade = model.Quantidade;
                produto.Peso = model.Peso;
                produto.Informacoes = model.Informacoes;
                produto.Imagem = model.Imagem;
                produto.DataCadastro = DateTime.Now;               
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

      
    }
}
