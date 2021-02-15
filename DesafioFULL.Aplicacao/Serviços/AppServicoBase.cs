using DesafioFULL.Aplicacao.Interfaces;
using DesafioFULL.Repositorio.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFULL.Aplicacao.Serviços
{
    public class AppServicoBase<TEntity> : IAppServicoBase<TEntity> where TEntity : class
    {
        protected readonly DesafioFULLContexto DesafioFULLContexto;

        public AppServicoBase(DesafioFULLContexto desafioFULLContexto)
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
