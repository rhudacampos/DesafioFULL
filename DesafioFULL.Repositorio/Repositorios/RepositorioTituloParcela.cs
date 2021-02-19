using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.Interfaces.Repositorios;
using DesafioFULL.Dominio.ViewModels;
using DesafioFULL.Repositorio.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFULL.Repositorio.Repositorios
{
    public class RepositorioTituloParcela : RepositorioBase<TituloParcela>, IRepositorioTituloParcela
    {
        public RepositorioTituloParcela(DesafioFULLContexto desafioFULLContexto) : base(desafioFULLContexto)
        {
        }

        public IList<TituloParcela> ObterPorTitulo(Titulo titulo)
        {
            return _desafioFULLContexto.TituloParcelas
                .Where(tp => tp.TituloId == titulo.Id)
                .OrderBy(tp => tp.Vencimento).ToList();
        }

        public IList<ViewModelTituloParcela> ObterPorTituloId(long tituloId)
        {
            //return _desafioFULLContexto.TituloParcelas
            //    .Where(tp => tp.TituloId == tituloId).ToList();
            var query = (from tituloParcelas in _desafioFULLContexto.TituloParcelas.AsQueryable().Distinct()
                         where tituloParcelas.TituloId == tituloId
                         orderby tituloParcelas.NumParcela
                         select new ViewModelTituloParcela
                         {
                             id = tituloParcelas.Id,
                             tituloId = tituloParcelas.TituloId,
                             numParcela = tituloParcelas.NumParcela,
                             vencimento = tituloParcelas.Vencimento,
                             _vencimento = tituloParcelas.Vencimento,
                             vlrOriginal = tituloParcelas.VlrOriginal,
                             vlrJuros = tituloParcelas.VlrJuros,
                             vlrMulta = tituloParcelas.VlrMulta,
                             vlrCorrigido = tituloParcelas.VlrCorrigido,
                             diasEmAtraso = tituloParcelas.DiasEmAtraso,
                         }
                                        );
            return query.ToList();
        }
    }
}
