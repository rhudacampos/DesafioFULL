using DesafioFULL.Dominio.Interfaces.Repositorios;
using DesafioFULL.Repositorio.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace DesafioFULL.Repositorio.Repositorios
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class
    {
        protected readonly DesafioFULLContexto _desafioFULLContexto;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositorioBase(DesafioFULLContexto desafioFULLContexto)
        {
            _desafioFULLContexto = desafioFULLContexto;
        }

        public void Adicionar(TEntity entity)
        {
            _desafioFULLContexto.Set<TEntity>().Add(entity);
            _desafioFULLContexto.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            _desafioFULLContexto.Set<TEntity>().Update(entity);
            _desafioFULLContexto.SaveChanges();
        }


        public TEntity ObterPorId(long id)
        {
            return _desafioFULLContexto.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _desafioFULLContexto.Set<TEntity>().ToList();
        }

        public void Remover(TEntity entity)
        {
            _desafioFULLContexto.Set<TEntity>().Remove(entity);
            _desafioFULLContexto.SaveChanges();
        }

        public virtual void AdicionarEmLote(IList<TEntity> entidades)
        {
            _dbSet.AddRange(entidades);
            _desafioFULLContexto.SaveChanges();
        }

        public virtual void AtualizarEmLote(IList<TEntity> entidades)
        {
            _dbSet.UpdateRange(entidades);
            _desafioFULLContexto.SaveChanges();
        }

        public void RemoverEmLote(IList<TEntity> entidades)
        {
            _dbSet.RemoveRange(entidades);
            _desafioFULLContexto.SaveChanges();
        }

        public TransactionScope TransactionScope()
        {
            return new TransactionScope();
        }

        public void Dispose()
        {
            _desafioFULLContexto.Dispose();
        }

        public int SaveChanges()
        {
           var retorno = _desafioFULLContexto.SaveChanges();
           return retorno;

        }
    }
}
