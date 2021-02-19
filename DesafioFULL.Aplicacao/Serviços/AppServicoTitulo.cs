using DesafioFULL.Aplicacao.Interfaces;
using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.Interfaces.Repositorios;
using DesafioFULL.Dominio.ViewModels;
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

                //using (var unidadeTrabalho = _repositorioTitulo.TransactionScope())
                //{

                _repositorioTitulo.Adicionar(titulo);
                //    unidadeTrabalho.Complete();
                //}
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

                using (var unidadeTrabalho = _repositorioTitulo.TransactionScope())
                {
                    var retornoTitulo = CalcularTitulo(titulo);
                    _repositorioTitulo.Atualizar(retornoTitulo);
                    unidadeTrabalho.Complete();
                }

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IEnumerable<ViewModelTitulo> ExcluirERetornarLista(Titulo titulo)
        {
            try
            {
                _repositorioTitulo.Remover(titulo);
                return _repositorioTitulo.ObterTodosTitulos();
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

                var retornoListaTitulos = _repositorioTitulo.ObterTodosTitulos();

                return retornoListaTitulos;
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
                    }
                    //if (listaTitulos.Count > 0)
                    //    _repositorioTitulo.AtualizarEmLote(listaTitulos);

                    _repositorioTituloVerificacao.Adicionar(
                        new TituloVerificacao
                        {
                            DataVerificacao = DateTime.Now
                        });
                    _repositorioTituloVerificacao.SaveChanges();
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
            decimal totalVlrOriginal = 0;
            int countParcela = 0;
            titulo.VlrCorrigido = 0;
            titulo.VlrJuros = 0;
            titulo.VlrMulta = 0;
            titulo.DiasEmAtraso = 0;

            var listaTituloParcela = _repositorioTituloParcela.ObterPorTitulo(titulo);
            foreach (var tituloParcela in listaTituloParcela)
            {
                countParcela += 1;
                var tituloParcelaCalculado = CalcularTituloParcela(ref titulo, tituloParcela, countParcela);

                totalVlrOriginal += tituloParcelaCalculado.VlrOriginal;
                titulo.VlrCorrigido += tituloParcelaCalculado.VlrCorrigido;
                titulo.VlrJuros += tituloParcelaCalculado.VlrJuros;
            }

            if (titulo.DiasEmAtraso > 0)
                titulo.VlrMulta = titulo.VlrOriginal * (titulo.PerMulta / 100);

            titulo.QtdeParcelas = listaTituloParcela.Count;
            if (totalVlrOriginal > titulo.VlrOriginal)
                titulo.VlrOriginal = totalVlrOriginal;

            //_repositorioTituloParcela.AtualizarEmLote(listaTituloParcela);
            return titulo;
        }

        public TituloParcela CalcularTituloParcela(ref Titulo titulo, TituloParcela tituloParcela, int numParcela)
        {
            decimal diasEmAtraso;
            diasEmAtraso = Convert.ToDecimal((DateTime.Today - tituloParcela.Vencimento).TotalDays);
            if (diasEmAtraso < 0)
            {
                diasEmAtraso = 0;
            }
            if (diasEmAtraso >= titulo.DiasEmAtraso)
            {
                titulo.DiasEmAtraso = (int)diasEmAtraso;
            }

            if (diasEmAtraso > 0)
            {
                tituloParcela.VlrMulta = tituloParcela.VlrOriginal * (titulo.PerMulta / 100);
                tituloParcela.VlrJuros = (titulo.PerJuros / 100) / 30 * diasEmAtraso * tituloParcela.VlrOriginal;
            }
            else
            {
                tituloParcela.VlrMulta = 0;
                tituloParcela.VlrJuros = 0;
            }

            tituloParcela.DiasEmAtraso = (int)diasEmAtraso;
            tituloParcela.VlrCorrigido = tituloParcela.VlrOriginal + tituloParcela.VlrMulta + tituloParcela.VlrJuros;
            tituloParcela.NumParcela = numParcela;
            return tituloParcela;
        }

        public void ValidarECadastrarParcela(TituloParcela tituloParcela)
        {
            try
            {
                tituloParcela.Validar();
                if (!tituloParcela.EhValido)
                {
                    throw new System.ArgumentException(tituloParcela.ObterMensagensValidacao());
                }


                using (var unidadeTrabalho = _repositorioTitulo.TransactionScope())
                {
                    _repositorioTituloParcela.Adicionar(tituloParcela);

                    var titulo = _repositorioTitulo.ObterPorId(tituloParcela.TituloId);
                    var retornoTitulo = CalcularTitulo(titulo);
                    _repositorioTitulo.Atualizar(retornoTitulo);

                    unidadeTrabalho.Complete();
                }

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void ValidarEAtualizarParcela(TituloParcela tituloParcela)
        {
            try
            {
                tituloParcela.Validar();
                if (!tituloParcela.EhValido)
                {
                    throw new System.ArgumentException(tituloParcela.ObterMensagensValidacao());
                }

                using (var unidadeTrabalho = _repositorioTitulo.TransactionScope())
                {
                    _repositorioTituloParcela.Atualizar(tituloParcela);

                    var titulo = _repositorioTitulo.ObterPorId(tituloParcela.TituloId);
                    var retornoTitulo = CalcularTitulo(titulo);
                    _repositorioTitulo.Atualizar(retornoTitulo);

                    unidadeTrabalho.Complete();
                }

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IEnumerable<ViewModelTituloParcela> ObterParcelasPorTitulo(Titulo titulo)
        {
            return _repositorioTituloParcela.ObterPorTituloId(titulo.Id);

        }

        public IEnumerable<ViewModelTituloParcela> ExcluirParcelaERetornarLista(TituloParcela tituloParcela)
        {
            try
            {
                var tituloId = tituloParcela.TituloId;
                using (var unidadeTrabalho = _repositorioTituloParcela.TransactionScope())
                {
                    _repositorioTituloParcela.Remover(tituloParcela);

                    var titulo = _repositorioTitulo.ObterPorId(tituloId);
                    var retornoTitulo = CalcularTitulo(titulo);
                    _repositorioTitulo.Atualizar(retornoTitulo);
                    unidadeTrabalho.Complete();
                }
                return _repositorioTituloParcela.ObterPorTituloId(tituloId);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public ViewModelTitulo ObterTituloPorId(long tituloId)
        {
            return _repositorioTitulo.ObterPorTituloId(tituloId);
        }
    }
}
