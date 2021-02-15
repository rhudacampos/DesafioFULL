using System;
using System.Collections.Generic;

namespace DesafioFULL.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        void Remover(TEntity entity);
        TEntity ObterPorId(long id);
        IEnumerable<TEntity> ObterTodos();
        
    }
}
