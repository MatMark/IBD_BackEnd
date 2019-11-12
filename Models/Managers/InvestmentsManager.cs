using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BackEnd.Models.Repository;

namespace BackEnd.Models.Managers
{
    public class InvestmentsManager : IBaseRepository<Investments>
    {
        W4rtaDBContext context;

        public InvestmentsManager(W4rtaDBContext context)
        {
            this.context = context;
        }

        public void Add(Investments entity)
        {
            context.Investments.Add(entity);
            context.SaveChanges();
        }

        public int Count()
        {
            return context.Set<Investments>().Count();
        }

        public void Delete(Investments entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Investments Get(int id)
        {
            return context.Investments.FirstOrDefault(e => e.Id == id);
        }

        public Investments Get(string id)
        {
            throw new NotImplementedException();
        }

        public Investments Get(Expression<Func<Investments, bool>> predicate)
        {
            return context.Investments.FirstOrDefault(predicate);
        }

        public IEnumerable<Investments> GetAll()
        {
            return context.Investments.ToList();
        }

        public void Update(Investments entity)
        {
            context.Investments.Update(entity);
            context.SaveChanges();
        }
    }
}
