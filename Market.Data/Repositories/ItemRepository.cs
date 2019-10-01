using Market.Entities.Entity;
using Market.Entities.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;

namespace Market.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private ISession session;
        public IQueryable<Item> GetAll()
        {
            return session.Query<Item>().AsQueryable();
        }
        public Item Get(Guid id)
        {
           return session.Get<Item>(id);
        }
        public void Insert(Item obj)
        {
            session.Save(obj);
        }
        public void Update(Item obj)
        {
            session.Update(obj);
        }
        public void Delete(Item obj)
        {
            session.Delete(obj);
        }
    }
}
