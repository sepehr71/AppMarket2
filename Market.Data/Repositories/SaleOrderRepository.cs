using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Entity;
using Market.Entities.Interfaces;
using NHibernate;
using NHibernate.Linq;

namespace Market.Data.Repositories
{
    public class SaleOrderRepository :ISaleOrderRepository
    {
        private ISession session;
        public IQueryable<Entities.Entity.SaleOrder> GetAll()
        {
            return session.Query<SaleOrder>().AsQueryable();
        }

        public Entities.Entity.SaleOrder Get(Guid id)
        {
            return session.Get<SaleOrder>(id);
        }

        public void Insert(SaleOrder obj)
        {
            session.Save(obj);
        }

        public void Update(SaleOrder obj)
        {
            session.Update(obj);
        }

        public void Delete(SaleOrder obj)
        {
            session.Delete(obj);
        }
    }
}