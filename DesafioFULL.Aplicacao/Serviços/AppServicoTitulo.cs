using DesafioFULL.Aplicacao.Interfaces;
using DesafioFULL.Aplicacao.ViewModels;
using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.Interfaces.Repositorios;
using DesafioFULL.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFULL.Aplicacao.Serviços
{
    public class AppServicoTitulo : AppServicoBase<Titulo>, IAppServicoTitulo
    {
        private readonly IRepositorioTitulo _repositorioTitulo;
        private readonly IRepositorioTituloParcela _repositorioTituloParcela;
        private readonly IRepositorioTituloVerificacao _repositorioTituloVerificacao;

        public AppServicoTitulo(DesafioFULLContexto desafioFULLContexto,
            IRepositorioTitulo repositorioTitulo,
            IRepositorioTituloParcela repositorioTituloParcela,
            IRepositorioTituloVerificacao repositorioTituloVerificacao) : base(desafioFULLContexto)
        {
            _repositorioTitulo = repositorioTitulo;
            _repositorioTituloParcela = repositorioTituloParcela;
            _repositorioTituloVerificacao = repositorioTituloVerificacao;
        }

        public void ValidarECadastrar(Titulo titulo)
        {
            try
            {
                titulo.Validar();
                if (!titulo.EhValido)
                {
                    throw new System.ArgumentException(titulo.ObterMensagensValidacao());
                }

                _repositorioTitulo.Adicionar(titulo);
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        public void ValidarEAtualizar(Titulo titulo)
        {
            try
            {
                titulo.Validar();
                if (!titulo.EhValido)
                {
                    throw new System.ArgumentException(titulo.ObterMensagensValidacao());
                }

                _repositorioTitulo.Atualizar(titulo);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IEnumerable<Titulo> ExcluirERetornarLista(Titulo titulo)
        {
            try
            {
                _repositorioTitulo.Remover(titulo);
                return _repositorioTitulo.ObterTodos();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IEnumerable<ViewModelTitulo> ObterListagemTitulos()
        {
            try
            {
                //verifica se ja foi calulado juros e multa hoje
                if (!CalculoEfetuado())
                {
                    ProcessarCalculoTitulos();
                };

                var listaTitulos = _repositorioTitulo.ObterTodos();
                var retornoLista = listaTitulos
                    .Select(t => new ViewModelTitulo
                    {
                        id = t.Id,
                        clienteId = t.ClienteId,
                        qtdeParcelas = t.QtdeParcelas,
                        perJuros = t.PerJuros,
                        perMulta = t.PerMulta,
                        vlrOriginal = t.VlrOriginal,
                        vlrCorrigido = t.VlrCorrigido,
                        nomeCliente = t.Cliente.Nome,
                        vlrJuros = t.VlrJuros,
                        vlrMulta = t.VlrMulta,
                        diasEmAtraso = t.DiasEmAtraso
                    });

                return retornoLista;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public bool CalculoEfetuado()
        {
            try
            {
                var verificacaoAtual = _repositorioTituloVerificacao.ObterVerificacaoAtual();
                var verificado = (verificacaoAtual != null);
                return verificado;

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void ProcessarCalculoTitulos()
        {
            try
            {
                using (var unidadeTrabalho = _repositorioTitulo.TransactionScope())
                {
                    var listaTitulos = _repositorioTitulo.ObterTodos().ToList();
                    foreach (var titulo in listaTitulos)
                    {
                        var tituloCalculado = CalcularTitulo(titulo);
                        titulo.VlrMulta = tituloCalculado.VlrMulta;
                        titulo.VlrJuros = tituloCalculado.VlrJuros;
                        titulo.VlrCorrigido = tituloCalculado.VlrCorrigido;
                        titulo.QtdeParcelas = tituloCalculado.QtdeParcelas;
                    }
                    _repositorioTitulo.AtualizarEmLote(listaTitulos);

                    _repositorioTituloVerificacao.Adicionar(
                        new TituloVerificacao
                        {
                            DataVerificacao = DateTime.Now
                        });

                    unidadeTrabalho.Complete();
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public Titulo CalcularTitulo(Titulo titulo)
        {
            titulo.VlrMulta = titulo.VlrOriginal * (titulo.PerMulta / 100);
            titulo.VlrCorrigido = 0;

            var listaTituloParcela = _repositorioTituloParcela.ObterPorTitulo(titulo);
            foreach (var tituloParcela in listaTituloParcela)
            {
                var tituloParcelaCalculado = CalcularTituloParcela(ref titulo, tituloParcela);
                tituloParcela.VlrJuros = tituloParcelaCalculado.VlrJuros;
                tituloParcela.VlrMulta = tituloParcelaCalculado.VlrMulta;
                tituloParcela.VlrCorrigido = tituloParcelaCalculado.VlrCorrigido;

                titulo.VlrCorrigido += tituloParcelaCalculado.VlrCorrigido;
            }

            titulo.QtdeParcelas = listaTituloParcela.Count;

            _repositorioTituloParcela.AtualizarEmLote(listaTituloParcela);
            return titulo;
        }

        public TituloParcela CalcularTituloParcela(ref Titulo titulo, TituloParcela tituloParcela)
        {
            decimal diasEmAtraso;
            diasEmAtraso = Convert.ToDecimal((DateTime.Today - tituloParcela.Vencimento).TotalDays);
            if (diasEmAtraso >= titulo.DiasEmAtraso)
            {
                titulo.DiasEmAtraso = (int)diasEmAtraso;
            }

            if (diasEmAtraso > 0)
            {
                tituloParcela.VlrMulta = tituloParcela.VlrOriginal * (titulo.PerMulta / 100);
            }
            else
            {
                tituloParcela.VlrMulta = 0;
            }

            tituloParcela.VlrJuros = (titulo.PerJuros / 100) / 30 * diasEmAtraso * tituloParcela.VlrOriginal;
            tituloParcela.VlrCorrigido = tituloParcela.VlrOriginal + tituloParcela.VlrMulta + tituloParcela.VlrJuros;

            return tituloParcela;
        }






    }
}
