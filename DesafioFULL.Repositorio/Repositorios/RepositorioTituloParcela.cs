using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.Interfaces.Repositorios;
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

        public List<TituloParcela> ObterPorTitulo(Titulo titulo)
        {
            var retorno = _desafioFULLContexto.TituloParcelas
                    .Where(tp => tp.TituloId == titulo.Id);
            return retorno.ToList();
        }
    }
}
