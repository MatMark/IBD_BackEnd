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
            throw new NotImplementedException();
        }

        public void Delete(Investments entity)
        {
            throw new NotImplementedException();
        }

        public Investments Get(int id)
        {
            throw new NotImplementedException();
        }

        public Investments Get(string id)
        {
            throw new NotImplementedException();
        }

        public Investments Get(Expression<Func<Investments, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Investments> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Investments entity)
        {
            throw new NotImplementedException();
        }
    }
}
