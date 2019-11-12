using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BackEnd.Models.Repository;

namespace BackEnd.Models.Managers
{
    public class TransferManager : IBaseRepository<Transfer>
    {
        W4rtaDBContext context;
        public TransferManager(W4rtaDBContext context)
        {
            this.context = context;
        }

        public int Add(Transfer entity)
        {
            context.Transfer.Add(entity);
            return (context.SaveChanges());
        }

        public int Count()
        {
            return context.Set<Transfer>().Count();
        }

        public int Delete(Transfer entity)
        {
            context.Remove(entity);
            return (context.SaveChanges());
        }

        public Transfer Get(int id)
        {
            return context.Transfer.FirstOrDefault(e => e.Id == id);
        }

        public Transfer Get(string id)
        {
            throw new NotImplementedException();
        }

        public Transfer Get(Expression<Func<Transfer, bool>> predicate)
        {
            return context.Transfer.FirstOrDefault(predicate);
        }

        public IEnumerable<Transfer> GetAll()
        {
            return context.Transfer.ToList();
        }

        public int Update(Transfer entity)
        {
            context.Transfer.Update(entity);
            return (context.SaveChanges());
        }
    }
}
