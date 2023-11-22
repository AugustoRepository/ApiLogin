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
    public class PedidoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(PedidoModel model,
            [FromServices] IPedidoRepository pedidoRepository,
            [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var email = User.Identity.Name; //email do usuário contido no TOKEN..
                var usuario = usuarioRepository.GetbyEmail(email);

                //criando um objeto da entidade pedido..
                var pedido = new Pedido();
                pedido.DataPedido = DateTime.Now;
                pedido.ValorTotal = model.ValorTotal;
                pedido.ValorTotal = model.ValorTotal;
                pedido.Status = model.Status;               
                pedido.IdUsuario = usuario.IdUsuario;

                //gravando a pedido no banco de dados..
                pedidoRepository.Add(pedido);

                return Ok("Pedido cadastrada com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro:" + e.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(PedidoEdicaoModel model,
           [FromServices] IPedidoRepository pedidoRepository,
           [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var email = User.Identity.Name;
                var usuario = usuarioRepository.GetbyEmail(email);

                var pedido = pedidoRepository.Get(model.IdPedido);

                pedido.IdPedido = pedido.IdPedido;
                pedido.DataPedido = DateTime.Now;
                pedido.ValorTotal = model.ValorTotal;
                pedido.ValorTotal = model.ValorTotal;
                pedido.Status = model.Status;
                pedido.IdUsuario = usuario.IdUsuario;

                //gravando a pedido no banco de dados..
                pedidoRepository.Update(pedido);

                return Ok("Pedido Alterado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro:" + e.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
           [FromServices] IPedidoRepository pedidoRepository,
           [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var email = User.Identity.Name;
                var usuario = usuarioRepository.GetbyEmail(email);

                var pedido = pedidoRepository.Get(id);

                if (pedido != null)
                {
                    pedidoRepository.Delete(pedido);
                    return Ok("Pedido excluída com sucesso.");
                }
                else
                {
                    return StatusCode(500, "pedido não encontrada.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll(
           [FromServices] IPedidoRepository pedidoRepository,
           [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var email = User.Identity.Name;
                var usuario = usuarioRepository.GetbyEmail(email);

                var lista = new List<PedidoConsultaModel>();

                foreach (var item in pedidoRepository.GetAll())
                {
                    var model = new PedidoConsultaModel();
                    model.IdPedido = item.IdPedido;
                    model.DataPedido = item.DataPedido;
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
           [FromServices] IPedidoRepository pedidoRepository,
           [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var email = User.Identity.Name;
                var usuario = usuarioRepository.GetbyEmail(email);

                var pedido = pedidoRepository.Get(id);

                if (pedido != null)
                {
                    var model = new PedidoConsultaModel();

                    model.IdPedido = pedido.IdPedido;
                    model.DataPedido = pedido.DataPedido;
                    model.ValorTotal = pedido.ValorTotal;
                    model.Status = pedido.Status;

                    return Ok(model);
                }
                else
                {
                    return StatusCode(500, "Pedido não encontrada.");
                }


            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }
    }
}
