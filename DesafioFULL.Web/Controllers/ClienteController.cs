using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesafioFULL.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly IRepositorioCliente _repositorioCliente;
        public ClienteController(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repositorioCliente.ObterTodos());
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
        public IActionResult Post([FromBody]Cliente cliente)
        {
            try
            {
                _repositorioCliente.Adicionar(cliente);
                return Created("api/cliente", cliente);
            }
            catch (Exception e)
            {

                return BadRequest(e.ToString());
            }
        }

    }
}
