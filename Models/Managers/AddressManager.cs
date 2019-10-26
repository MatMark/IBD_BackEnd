using BackEnd.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BackEnd.Models.Managers
{
    public class AddressManager : IBaseRepository<Address>
    {

        W4rtaDBContext context;
        public AddressManager(W4rtaDBContext context)
        {
            this.context = context;
        }
        public void Add(Address entity)
        {
            context.Address.Add(entity);
            context.SaveChanges();
        }

        public int Count()
        {
            return context.Set<Address>().Count();
        }

        public void Delete(Address entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Address Get(int id)
        {
            return context.Address.FirstOrDefault(e => e.Id == id);
        }

        public Address Get(string id)
        {
            throw new NotImplementedException();
        }

        public Address Get(Expression<Func<Address, bool>> predicate)
        {
            return context.Address.FirstOrDefault(predicate);
        }

        public IEnumerable<Address> GetAll()
        {
            return context.Address.ToList();
        }

        public void Update(Address entity)
        {
            context.Address.Update(entity);
            context.SaveChanges();
        }
    }
}
