using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Dominio.Interfaces.Repositorios;
using DesafioFULL.Dominio.ViewModels;
using DesafioFULL.Repositorio.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFULL.Repositorio.Repositorios
{
    public class RepositorioTitulo : RepositorioBase<Titulo>, IRepositorioTitulo
    {
        public RepositorioTitulo(DesafioFULLContexto desafioFULLContexto) : base(desafioFULLContexto)
        {
        }

        public IEnumerable<ViewModelTitulo> ObterTodosTitulos()
        {
            var query = (from titulos in _desafioFULLContexto.Titulos.AsQueryable().Distinct()
                         select new ViewModelTitulo
                         {
                             id = titulos.Id,
                             clienteId = titulos.ClienteId,
                             nomeCliente = titulos.Cliente.Nome + " " + titulos.Cliente.SobreNome,
                             cpfCliente = titulos.Cliente.CPF,
                             diasEmAtraso = titulos.DiasEmAtraso,
                             perJuros = titulos.DiasEmAtraso,
                             perMulta = titulos.PerMulta,
                             vlrOriginal = titulos.VlrOriginal,
                             vlrCorrigido = titulos.VlrCorrigido,
                             qtdeParcelas = titulos.QtdeParcelas,
                             vlrJuros = titulos.VlrJuros,
                             vlrMulta = titulos.VlrMulta
                         }
                                         );


            return query.ToList();
        }
    }
}
