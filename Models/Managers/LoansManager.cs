using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BackEnd.Models.Repository;

namespace BackEnd.Models.Managers
{
    public class LoansManager : IBaseRepository<Loans>
    {
        W4rtaDBContext context;
        public LoansManager(W4rtaDBContext context)
        {
            this.context = context;
        }

        public void Add(Loans entity)
        {
            context.Loans.Add(entity);
            context.SaveChanges();
        }

        public int Count()
        {
            return context.Set<Loans>().Count();
        }

        public void Delete(Loans entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Loans Get(int id)
        {
            return context.Loans.FirstOrDefault(e => e.ID == id);
        }

        public Loans Get(string id)
        {
            throw new NotImplementedException();
        }

        public Loans Get(Expression<Func<Loans, bool>> predicate)
        {
            return context.Loans.FirstOrDefault(predicate);
        }

        public IEnumerable<Loans> GetAll()
        {
            return context.Loans.ToList();
        }

        public void Update(Loans entity)
        {
            context.Loans.Update(entity);
            context.SaveChanges();
        }
    }
}
