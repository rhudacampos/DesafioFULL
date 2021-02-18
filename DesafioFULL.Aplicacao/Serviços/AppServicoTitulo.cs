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

            titulo.VlrCorrigido = 0;
            titulo.VlrJuros = 0;
            titulo.VlrMulta = 0;
            titulo.DiasEmAtraso = 0;
            var listaTituloParcela = _repositorioTituloParcela.ObterPorTitulo(titulo);
            foreach (var tituloParcela in listaTituloParcela)
            {
                var tituloParcelaCalculado = CalcularTituloParcela(ref titulo, tituloParcela);
                

                titulo.VlrCorrigido += tituloParcelaCalculado.VlrCorrigido;
                titulo.VlrJuros += tituloParcelaCalculado.VlrJuros;
            }

            if (titulo.DiasEmAtraso > 0)
              titulo.VlrMulta = titulo.VlrOriginal * (titulo.PerMulta / 100);

            titulo.QtdeParcelas = listaTituloParcela.Count;

            //_repositorioTituloParcela.AtualizarEmLote(listaTituloParcela);
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
