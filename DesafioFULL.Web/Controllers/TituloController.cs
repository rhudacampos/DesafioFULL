using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesafioFULL.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TituloController : Controller
    {
        private readonly IRepositorioTitulo _repositorioTitulo;
        public TituloController(IRepositorioTitulo repositorioTitulo)
        {
            _repositorioTitulo = repositorioTitulo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repositorioTitulo.ObterTodos());
                //if(condicao == false)
                //{
                //    return BadRequest("");
                //}
            }
            catch (Exception e)
            {

                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Titulo Titulo)
        {
            try
            {
                _repositorioTitulo.Adicionar(Titulo);
                return Created("titulo", Titulo);
            }
            catch (Exception e)
            {

                return BadRequest(e.ToString());
            }
        }

    }
}
