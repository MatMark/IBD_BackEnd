using BackEnd.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BackEnd.Models.Managers
{
    public class AddressesManager : IBaseRepository<Addresses>
    {

        W4rtaDBContext context;
        public AddressesManager(W4rtaDBContext context)
        {
            this.context = context;
        }
        public void Add(Addresses entity)
        {
            context.Addresses.Add(entity);
            context.SaveChanges();
        }

        public int Count()
        {
            return context.Set<Addresses>().Count();
        }

        public void Delete(Addresses entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Addresses Get(int id)
        {
            return context.Addresses.FirstOrDefault(e => e.Id == id);
        }

        public Addresses Get(string id)
        {
            throw new NotImplementedException();
        }

        public Addresses Get(Expression<Func<Addresses, bool>> predicate)
        {
            return context.Addresses.FirstOrDefault(predicate);
        }

        public IEnumerable<Addresses> GetAll()
        {
            return context.Addresses.ToList();
        }

        public void Update(Addresses entity)
        {
            context.Addresses.Update(entity);
            context.SaveChanges();
        }
    }
}
