using BackEnd.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BackEnd.Models.Managers
{
    public class ClientsManager : IBaseRepository<Clients>
    {

        W4rtaDBContext context;

        public ClientsManager(W4rtaDBContext context)
        {
            this.context = context;
        }

        public void Add(Clients entity)
        {
            context.Clients.Add(entity);
            context.SaveChanges();
        }

        public int Count()
        {
            return context.Set<Clients>().Count();
        }

        public void Delete(Clients entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Clients Get(int id)
        {
            return context.Clients.FirstOrDefault(e => e.Id == id);
        }

        public Clients Get(string id)
        {
            throw new NotImplementedException();
        }

        public Clients Get(Expression<Func<Clients, bool>> predicate)
        {
            return context.Clients.FirstOrDefault(predicate);
        }

        public IEnumerable<Clients> GetAll()
        {
            return context.Clients.ToList();
        }

        public void Update(Clients entity)
        {
            context.Clients.Update(entity);
            context.SaveChanges();
        }
    }
}