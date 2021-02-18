using System;
using System.Collections.Generic;
using System.Transactions;

namespace DesafioFULL.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        void Remover(TEntity entity);
        TEntity ObterPorId(long id);
        IEnumerable<TEntity> ObterTodos();
        void AdicionarEmLote(IList<TEntity> entidades);
        void AtualizarEmLote(IList<TEntity> entidades);
        void RemoverEmLote(IList<TEntity> entidades);
        int SaveChanges();

        TransactionScope TransactionScope();

    }
}
