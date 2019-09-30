using Market.Entities.Entity;
using Market.Entities.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private ISession session;
        public IQueryable<Item> GetAll()
        {
            throw new NotImplementedException();
        }

        public Item Get(Guid id)
        {
            Item item = session.Get<Item>(itemId);
            return item;
        }

        public void Insert(Item obj)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(obj);
                transaction.Commit();
            }
        }

        public void Update(Item obj)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(obj);
                transaction.Commit();
            }
        }

        public void Delete(Item obj)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(obj);
                transaction.Commit();
            }
        }
    }
}
