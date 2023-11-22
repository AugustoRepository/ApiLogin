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
    public class ProdutoController : ControllerBase
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
        [HttpPut]
        public IActionResult Put(ProdutoEdicaoModel model,
           [FromServices] IProdutoRepository produtoRepository,
           [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var email = User.Identity.Name;
                var usuario = usuarioRepository.GetbyEmail(email);

                var produto = produtoRepository.Get(model.Id);

                produto.Nome = model.Nome;
                produto.Preco = model.Preco;
                produto.Quantidade = model.Quantidade;
                produto.Peso = model.Peso;
                produto.Informacoes = model.Informacoes;
                produto.Imagem = model.Imagem;
                produto.DataCadastro = DateTime.Now;
                produto.IdUsuario = usuario.IdUsuario;

                //gravando a produto no banco de dados..
                produtoRepository.Update(produto);

                return Ok("Produto Alterado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro:" + e.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
           [FromServices] IProdutoRepository produtoRepository,
           [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var email = User.Identity.Name;
                var usuario = usuarioRepository.GetbyEmail(email);

                var produto = produtoRepository.Get(id);

                if (produto != null)
                {
                    produtoRepository.Delete(produto);
                    return Ok("produto excluída com sucesso.");
                }
                else
                {
                    return StatusCode(500, "produto não encontrada.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll(
           [FromServices] IProdutoRepository produtoRepository,
           [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var email = User.Identity.Name;
                var usuario = usuarioRepository.GetbyEmail(email);

                var lista = new List<ProdutoConsultaModel>();

                foreach (var item in produtoRepository.GetAll())
                {
                    var model = new ProdutoConsultaModel();
                    model.Id = item.IdProduto;
                    model.IdUsuario = item.IdUsuario;
                    model.Nome = item.Nome;
                    model.Preco = item.Preco;
                    model.Quantidade = item.Quantidade;
                    model.Informacoes = item.Informacoes;
                    model.DataCadastro = item.DataCadastro.ToString("dd/MM/yyyy");
                    model.Imagem = item.Imagem;


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
           [FromServices] IProdutoRepository produtoRepository,
           [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var email = User.Identity.Name;
                var usuario = usuarioRepository.GetbyEmail(email);

                var produto = produtoRepository.Get(id);

                if (produto != null)
                {
                    var model = new ProdutoConsultaModel();

                    model.Id = produto.IdProduto;
                    model.Nome = produto.Nome;
                    model.Preco = produto.Preco;
                    model.Quantidade = produto.Quantidade;
                    model.Informacoes = produto.Informacoes;
                    model.DataCadastro = produto.DataCadastro.ToString("dd/MM/yyyy");
                    model.Imagem = produto.Imagem;

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
