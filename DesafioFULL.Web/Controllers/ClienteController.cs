using DesafioFULL.Aplicacao.Interfaces;
using DesafioFULL.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesafioFULL.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly IAppServicoCliente _appServicoCliente;
        public ClienteController(IAppServicoCliente appServicoCliente)
        {
            _appServicoCliente = appServicoCliente;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_appServicoCliente.ObterTodos());
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
                _appServicoCliente.Adicionar(cliente);
                return Created("cliente", cliente);
            }
            catch (Exception e)
            {

                return BadRequest(e.ToString());
            }
        }

    }
}
