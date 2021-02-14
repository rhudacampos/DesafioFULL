using DesafioFULL.Dominio.Interfaces;
using DesafioFULL.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFULL.Repositorio.Repositorios
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class
    {
        protected readonly DesafioFULLContexto DesafioFULLContexto;

        public RepositorioBase(DesafioFULLContexto desafioFULLContexto)
        {
            DesafioFULLContexto = desafioFULLContexto;
        }

        public void Adicionar(TEntity entity)
        {
            DesafioFULLContexto.Set<TEntity>().Add(entity);
            DesafioFULLContexto.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            DesafioFULLContexto.Set<TEntity>().Update(entity);
            DesafioFULLContexto.SaveChanges();
        }
        

        public TEntity ObterPorId(long id)
        {
            return DesafioFULLContexto.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return DesafioFULLContexto.Set<TEntity>().ToList();
        }

        public void Remover(TEntity entity)
        {
            DesafioFULLContexto.Set<TEntity>().Remove(entity);
            DesafioFULLContexto.SaveChanges();
        }

        public void Dispose()
        {
            DesafioFULLContexto.Dispose();
        }
    }
}
