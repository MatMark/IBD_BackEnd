using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BackEnd.Models.Repository;

namespace BackEnd.Models.Managers
{
    public class LoanManager : IBaseRepository<Loan>
    {
        W4rtaDBContext context;
        public LoanManager(W4rtaDBContext context)
        {
            this.context = context;
        }

        public int Add(Loan entity)
        {
            context.Loan.Add(entity);
            return (context.SaveChanges());
        }

        public int Count()
        {
            return context.Set<Loan>().Count();
        }

        public int Delete(Loan entity)
        {
            context.Remove(entity);
            return (context.SaveChanges());
        }

        public Loan Get(int id)
        {
            return context.Loan.FirstOrDefault(e => e.Id == id);
        }

        public Loan Get(string id)
        {
            throw new NotImplementedException();
        }

        public Loan Get(Expression<Func<Loan, bool>> predicate)
        {
            return context.Loan.FirstOrDefault(predicate);
        }

        public IEnumerable<Loan> GetAll()
        {
            return context.Loan.ToList();
        }

        public int Update(Loan entity)
        {
            context.Loan.Update(entity);
            return (context.SaveChanges());
        }
    }
}
