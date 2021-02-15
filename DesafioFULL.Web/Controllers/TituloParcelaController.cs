using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.Interfaces.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesafioFULL.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TituloParcelaController : Controller
    {
        private readonly IRepositorioTituloParcela _repositorioTituloParcela;
        public TituloParcelaController(IRepositorioTituloParcela repositorioTituloParcela)
        {
            _repositorioTituloParcela = repositorioTituloParcela;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repositorioTituloParcela.ObterTodos());
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
        public IActionResult Post([FromBody]TituloParcela TituloParcela)
        {
            try
            {
                _repositorioTituloParcela.Adicionar(TituloParcela);
                return Created("tituloParcela", TituloParcela);
            }
            catch (Exception e)
            {

                return BadRequest(e.ToString());
            }
        }

    }
}
