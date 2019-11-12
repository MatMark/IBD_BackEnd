using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BackEnd.Models.Repository;

namespace BackEnd.Models.Managers
{
    public class InvestmentManager : IBaseRepository<Investment>
    {
        W4rtaDBContext context;

        public InvestmentManager(W4rtaDBContext context)
        {
            this.context = context;
        }

        public int Add(Investment entity)
        {
            context.Investment.Add(entity);
            return (context.SaveChanges());
        }

        public int Count()
        {
            return context.Set<Investment>().Count();
        }

        public int Delete(Investment entity)
        {
            context.Remove(entity);
            return (context.SaveChanges());
        }

        public Investment Get(int id)
        {
            return context.Investment.FirstOrDefault(e => e.Id == id);
        }

        public Investment Get(string id)
        {
            throw new NotImplementedException();
        }

        public Investment Get(Expression<Func<Investment, bool>> predicate)
        {
            return context.Investment.FirstOrDefault(predicate);
        }

        public IEnumerable<Investment> GetAll()
        {
            return context.Investment.ToList();
        }

        public int Update(Investment entity)
        {
            context.Investment.Update(entity);
            return (context.SaveChanges());
        }
    }
}
