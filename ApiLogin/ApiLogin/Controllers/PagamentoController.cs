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
    public class PagamentoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(PagamentoModel model,
            [FromServices] IPagamentoRepository pagamentoRepository,
            [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var email = User.Identity.Name; //email do usuário contido no TOKEN..
                var usuario = usuarioRepository.GetbyEmail(email);

                //criando um objeto da entidade pagamento..
                var pagamento = new Pagamento();
                pagamento.DataPagamento = DateTime.Now;
                pagamento.MetodoPagamento = model.MetodoPagamento;
                pagamento.Status = model.Status;               
                pagamento.PedidoId = model.ped

                //gravando a pagamento no banco de dados..
                pagamentoRepository.Add(pagamento);

                return Ok("Pagamento cadastrada com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro:" + e.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(PagamentoEdicaoModel model,
           [FromServices] IPagamentoRepository pagamentoRepository,
           [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var email = User.Identity.Name;
                var usuario = usuarioRepository.GetbyEmail(email);

                var pagamento = pagamentoRepository.Get(model.IdPagamento);

                pagamento.IdPagamento = pagamento.IdPagamento;
                pagamento.DataPagamento = DateTime.Now;
                pagamento.ValorTotal = model.ValorTotal;
                pagamento.ValorTotal = model.ValorTotal;
                pagamento.Status = model.Status;
                pagamento.IdUsuario = usuario.IdUsuario;

                //gravando a pagamento no banco de dados..
                pagamentoRepository.Update(pagamento);

                return Ok("Pagamento Alterado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro:" + e.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
           [FromServices] IPagamentoRepository pagamentoRepository,
           [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var email = User.Identity.Name;
                var usuario = usuarioRepository.GetbyEmail(email);

                var pagamento = pagamentoRepository.Get(id);

                if (pagamento != null)
                {
                    pagamentoRepository.Delete(pagamento);
                    return Ok("Pagamento excluída com sucesso.");
                }
                else
                {
                    return StatusCode(500, "pagamento não encontrada.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll(
           [FromServices] IPagamentoRepository pagamentoRepository,
           [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var email = User.Identity.Name;
                var usuario = usuarioRepository.GetbyEmail(email);

                var lista = new List<PagamentoConsultaModel>();

                foreach (var item in pagamentoRepository.GetAll())
                {
                    var model = new PagamentoConsultaModel();
                    model.IdPagamento = item.IdPagamento;
                    model.DataPagamento = item.DataPagamento;
                    model.ValorTotal = item.ValorTotal;
                    model.Status = item.Status;                   

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
           [FromServices] IPagamentoRepository pagamentoRepository,
           [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var email = User.Identity.Name;
                var usuario = usuarioRepository.GetbyEmail(email);

                var pagamento = pagamentoRepository.Get(id);

                if (pagamento != null)
                {
                    var model = new PagamentoConsultaModel();

                    model.IdPagamento = pagamento.IdPagamento;
                    model.DataPagamento = pagamento.DataPagamento;
                    model.ValorTotal = pagamento.ValorTotal;
                    model.Status = pagamento.Status;

                    return Ok(model);
                }
                else
                {
                    return StatusCode(500, "Pagamento não encontrada.");
                }


            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }
    }
}
