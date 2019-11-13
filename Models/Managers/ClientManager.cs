using BackEnd.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BackEnd.Models.Managers
{
    public class ClientManager : IBaseRepository<Client>
    {

        W4rtaDBContext context;

        public ClientManager(W4rtaDBContext context)
        {
            this.context = context;
        }

        public int Add(Client entity)
        {
            context.Client.Add(entity);
            return (context.SaveChanges());
        }

        public int Count()
        {
            return context.Set<Client>().Count();
        }

        public int Delete(Client entity)
        {
            context.Remove(entity);
            return (context.SaveChanges());
        }

        public Client Get(int id)
        {
            return context.Client.FirstOrDefault(e => e.Id == id);
        }

        public Client Get(string email)
        {
            return context.Client.FirstOrDefault(e => e.Email == email);
        }

        public Client Get(Expression<Func<Client, bool>> predicate)
        {
            return context.Client.FirstOrDefault(predicate);
        }

        public IEnumerable<Client> GetAll()
        {
            return context.Client.ToList();
        }

        public int Update(Client entity)
        {
            context.Client.Update(entity);
            return (context.SaveChanges());
        }
    }
}