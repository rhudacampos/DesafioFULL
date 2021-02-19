using DesafioFULL.Aplicacao.Interfaces;
using DesafioFULL.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesafioFULL.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TituloParcelaController : Controller
    {
        private readonly IAppServicoTitulo _appServicoTitulo;
        public TituloParcelaController(IAppServicoTitulo appServicoTitulo)
        {
            _appServicoTitulo = appServicoTitulo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_appServicoTitulo.ObterTodos());
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
        public IActionResult Post([FromBody]TituloParcela tituloParcela)
        {
            try
            {
                if (tituloParcela.Id > 0)
                {
                    _appServicoTitulo.ValidarEAtualizarParcela(tituloParcela);
                }
                else
                {
                    _appServicoTitulo.ValidarECadastrarParcela(tituloParcela);
                }

                return Created("TituloParcela", tituloParcela);
            }
            catch (Exception e)
            {

                return BadRequest(e.ToString());
            }
        }
        
        [HttpPost("parcelasPorTitulo")]
        public IActionResult Obter([FromBody] Titulo titulo)
        {
            try
            {
                var tituloParcelas = _appServicoTitulo.ObterParcelasPorTitulo(titulo);
                return Created("TituloParcela", tituloParcelas);
            }
            catch (Exception e)
            {

                return BadRequest(e.ToString());
            }
        }

        [HttpPost("excluir")]
        public IActionResult Excluir([FromBody] TituloParcela tituloParcela)
        {
            try
            {
                var retorno = _appServicoTitulo.ExcluirParcelaERetornarLista(tituloParcela);
                return Json(retorno);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}
