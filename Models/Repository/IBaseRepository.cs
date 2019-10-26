using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository
{
    interface IBaseRepository<TEntity>
    {
        TEntity Get(int id);
        TEntity Get(string id);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        int Count();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
