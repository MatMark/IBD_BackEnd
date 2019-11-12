using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BackEnd.Models.Repository;

namespace BackEnd.Models.Managers
{
    public class AccountsManager : IBaseRepository <Accounts>
    {
        W4rtaDBContext context;
        public AccountsManager(W4rtaDBContext context)
        {
            this.context = context;
        }

        public void Add(Accounts entity)
        {
            context.Accounts.Add(entity);
            context.SaveChanges();
        }

        public int Count()
        {
            return context.Set<Accounts>().Count();
        }

        public void Delete(Accounts entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public Accounts Get(int id)
        {
            return context.Accounts.FirstOrDefault(e => e.ID == id);
        }

        public Accounts Get(string id)
        {
            throw new NotImplementedException();
        }

        public Accounts Get(Expression<Func<Accounts, bool>> predicate)
        {
            return context.Accounts.FirstOrDefault(predicate);
        }

        public IEnumerable<Accounts> GetAll()
        {
            return context.Accounts.ToList();
        }

        public void Update(Accounts entity)
        {
            context.Accounts.Update(entity);
            context.SaveChanges();
        }
    }
}
