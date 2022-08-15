using ApiLogin.Repository.Contracts;
using System;
using Microsoft.AspNetCore.Mvc;
using ApiLogin.Presentation.Model;
using System.Collections.Generic;

namespace ApiLogin.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfisController : ControllerBase
    {
        [HttpGet]
        public IActionResult GEtAll([FromServices] IPerfilRepository perfilRepository)
        {
            try
            {
                var perfis = new List<PerfilConsultaModel>();

                foreach( var item in perfilRepository.GetAll())
                {
                    var model = new PerfilConsultaModel();
                    model.IdPerfil = item.IdPerfil;
                    model.Nome = item.Nome;
                    perfis.Add(model);
                }
                return Ok(perfis);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro: " + e.Message);
            }
        }
    }
}
