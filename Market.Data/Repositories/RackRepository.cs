using Market.Entities.Entity;
using Market.Entities.Interfaces;
using NHibernate;
using System.Linq;
using NHibernate.Linq;

namespace Market.Data.Repositories
{
   public class RackRepository :IRackRepository
    {
       private ISession session;
       public IQueryable<Rack> GetAll()
       {
           return session.Query<Rack>().AsQueryable();
       }

       public Rack Get(System.Guid id)
       {
           return session.Get<Rack>(id);
       }

       public void Insert(Rack obj)
       {
           session.Save(obj);
       }

       public void Update(Rack obj)
       {
           session.Update(obj);
       }

       public void Delete(Rack obj)
       {
           throw new System.NotImplementedException();
       }
    }
}
