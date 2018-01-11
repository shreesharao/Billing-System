using System.Collections.Generic;
using System.Linq.Expressions;

using BillingSystem.DAO.Abstractions;


namespace BillingSystem.DAO
{
    public class CommonRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        public virtual IEnumerable<TEntity> Get(Expression<System.Func<TEntity, bool>> filter, System.Func<System.Linq.IQueryable<TEntity>, System.Linq.IOrderedQueryable<TEntity>> orderBy, string includeProperties)
        {
            throw new System.NotImplementedException();
        }

        public virtual TEntity GetById(object Id)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Insert(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Delete(object Id)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Delete(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
