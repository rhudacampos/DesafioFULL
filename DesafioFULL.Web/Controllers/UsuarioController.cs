using DesafioFULL.Aplicacao.Interfaces;
using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.Interfaces.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesafioFULL.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        //private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IAppServicoUsuario _appServicoUsuario;
        public UsuarioController(IAppServicoUsuario appServicoUsuario)
        {
            _appServicoUsuario = appServicoUsuario;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_appServicoUsuario.ObterTodos());
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
        public IActionResult Post([FromBody]Usuario Usuario)
        {
            try
            {
                _appServicoUsuario.Adicionar(Usuario);
                return Created("Usuario", Usuario);
            }
            catch (Exception e)
            {

                return BadRequest(e.ToString());
            }
        }

        [HttpPost("VerificarUsuario")]
        public IActionResult VerificarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioRetorno = _appServicoUsuario.AutenticarUsuario(usuario.Email, usuario.Senha);
                if (usuarioRetorno != null)
                {
                    return Ok(usuarioRetorno);
                }

                return BadRequest("Usuário ou senha inválido");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
