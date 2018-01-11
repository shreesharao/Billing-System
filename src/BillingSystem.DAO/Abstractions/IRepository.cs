using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.DAO.Abstractions
{
    interface IRepository<TEntity> where TEntity:class
    {
        //making the methods virtual so that they can be overrriden later
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            string includeProperties);

        TEntity GetById(object Id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(object Id);

        void Delete(TEntity entity);

    }
}
