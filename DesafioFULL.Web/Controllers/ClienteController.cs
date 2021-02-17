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
            }
            catch (Exception e)
            {

                return BadRequest(e.ToString());
            }
        }

        [HttpGet("obter")]
        public IActionResult Obter([FromBody] Cliente cliente)
        {
            try
            {
                return Ok(_appServicoCliente.ObterPorId(cliente.Id));
            }
            catch (Exception e)
            {

                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                if (cliente.Id > 0)
                {
                    _appServicoCliente.ValidarEAtualizar(cliente);
                }
                else
                {
                    _appServicoCliente.ValidarECadastrar(cliente);
                }
                
                return Created("Cliente", cliente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost("excluir")]
        public IActionResult Excluir([FromBody] Cliente cliente)
        {
            try
            {
                var retorno = _appServicoCliente.ExcluirERetornarLista(cliente);
                return Json(retorno);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
