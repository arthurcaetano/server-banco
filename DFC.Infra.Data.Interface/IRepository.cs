using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DFC.Infra.Data.Interface
{
    public interface IRepository<TEntity> : IDisposable
    {
        void Adicionar(TEntity obj);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity obj);
        void Remover(int id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}