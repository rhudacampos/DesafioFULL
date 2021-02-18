using DesafioFULL.Aplicacao.Interfaces;
using DesafioFULL.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesafioFULL.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TituloController : Controller
    {
        private readonly IAppServicoTitulo _appServicoTitulo;
        public TituloController(IAppServicoTitulo appServicoTitulo)
        {
            _appServicoTitulo = appServicoTitulo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_appServicoTitulo.ObterListagemTitulos());
            }
            catch (Exception e)
            {

                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Titulo titulo)
        {
            try
            {
                if (titulo.Id > 0)
                {
                    _appServicoTitulo.ValidarEAtualizar(titulo);
                }
                else
                {
                    _appServicoTitulo.ValidarECadastrar(titulo);
                }

                return Created("Cliente", titulo);
            }
            catch (Exception e)
            {

                return BadRequest(e.ToString());
            }
        }

    }
}
