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
        public IActionResult Post([FromBody] Titulo titulo)
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

                return Created("Titulo", titulo);
            }
            catch (Exception e)
            {

                return BadRequest(e.ToString());
            }
        }

        [HttpPost("obterTitulo")]
        public IActionResult OnterTitulo([FromBody] Titulo titulo)
        {
            try
            {
                var tituloParcelas = _appServicoTitulo.ObterPorId(titulo.Id);
                return Created("Titulo", titulo);
            }
            catch (Exception e)
            {

                return BadRequest(e.ToString());
            }
        }


        [HttpPost("parcelasPorTitulo")]
        public IActionResult ObterParcelas([FromBody] Titulo titulo)
        {
            try
            {
                var tituloParcelas = _appServicoTitulo.ObterParcelasPorTitulo(titulo);
                return Created("TituloParcelas", tituloParcelas);
            }
            catch (Exception e)
            {

                return BadRequest(e.ToString());
            }
        }


        [HttpPost("excluir")]
        public IActionResult Excluir([FromBody] Titulo titulo)
        {
            try
            {
                var retorno = _appServicoTitulo.ExcluirERetornarLista(titulo);
                return Json(retorno);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}

