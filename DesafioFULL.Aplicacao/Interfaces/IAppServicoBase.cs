using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFULL.Aplicacao.Interfaces
{
    public interface IAppServicoBase<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        void Remover(TEntity entity);
        TEntity ObterPorId(long id);
        IEnumerable<TEntity> ObterTodos();

    }
}
