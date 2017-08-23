using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Contracts
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {     
        void Commit();

        void Add(TEntity entity);
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
