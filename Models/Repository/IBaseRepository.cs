﻿using System;
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
        int Add(TEntity entity);
        int Update(TEntity entity);
        int Delete(TEntity entity);
    }
}
