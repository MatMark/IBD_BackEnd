using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BackEnd.Models.Repository;

namespace BackEnd.Models.Managers
{
    public class TransfersManager : IBaseRepository<Transfers>
    {
        W4rtaDBContext context;
        public TransfersManager(W4rtaDBContext context)
        {
            this.context = context;
        }

        public void Add(Transfers entity)
        {
            context.Transfers.Add(entity);
            context.SaveChanges();
        }

        public int Count()
        {
            return context.Set<Transfers>().Count();
        }

        public void Delete(Transfers entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Transfers Get(int id)
        {
            return context.Transfers.FirstOrDefault(e => e.ID == id);
        }

        public Transfers Get(string id)
        {
            throw new NotImplementedException();
        }

        public Transfers Get(Expression<Func<Transfers, bool>> predicate)
        {
            return context.Transfers.FirstOrDefault(predicate);
        }

        public IEnumerable<Transfers> GetAll()
        {
            return context.Transfers.ToList();
        }

        public void Update(Transfers entity)
        {
            context.Transfers.Update(entity);
            context.SaveChanges();
        }
    }
}
