using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BackEnd.Models.Repository;

namespace BackEnd.Models.Managers
{
    public class AccountManager : IBaseRepository <Account>
    {
        W4rtaDBContext context;
        public AccountManager(W4rtaDBContext context)
        {
            this.context = context;
        }

        public int Add(Account entity)
        {
            context.Account.Add(entity);
            return (context.SaveChanges());
        }

        public int Count()
        {
            return context.Set<Account>().Count();
        }

        public int Delete(Account entity)
        {
            context.Remove(entity);
            return (context.SaveChanges());
        }

        public Account Get(int id)
        {
            return context.Account.FirstOrDefault(e => e.Id == id);
        }

        public Account Get(string number)
        {
            return context.Account.FirstOrDefault(e => e.Number == number);
        }

        public Account Get(Expression<Func<Account, bool>> predicate)
        {
            return context.Account.FirstOrDefault(predicate);
        }

        public IEnumerable<Account> GetAll()
        {
            return context.Account.ToList();
        }

        public int Update(Account entity)
        {
            context.Account.Update(entity);
            return (context.SaveChanges());
        }
    }
}
