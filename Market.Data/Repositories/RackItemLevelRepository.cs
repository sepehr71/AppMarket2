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
   public class RackItemLevelRepository : IRackItemLevelRepository
    {
       private ISession session;

       public IQueryable<RackItemLevel> GetAll()
       {
           return session.Query<RackItemLevel>().AsQueryable();
       }

       public RackItemLevel Get(Guid id)
       {
           return session.Get<RackItemLevel>(id);
       }

       public void Insert(RackItemLevel obj)
       {
           session.Save(obj);
       }

       public void Update(RackItemLevel obj)
       {
           session.Update(obj);
       }

       public void Delete(RackItemLevel obj)
       {
           session.Delete(obj);
       }
    }
}
