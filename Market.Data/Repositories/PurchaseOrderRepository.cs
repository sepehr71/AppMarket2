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
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private ISession session;



        public IQueryable<PurchaseOrder> GetAll()
        {
            throw new NotImplementedException();
        }

        public PurchaseOrder Get(Guid id)
        {
            
        }

        public void Insert(PurchaseOrder obj)
        {
            throw new NotImplementedException();
        }

        public void Update(PurchaseOrder obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(PurchaseOrder obj)
        {
            throw new NotImplementedException();
        }
    }
}
