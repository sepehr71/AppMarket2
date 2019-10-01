using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Interfaces;
using Market.Entities.Contracts;
using Market.Entities.Entity;

namespace Market.Services
{
    public class RackServices
    {
        public IRackRepository IRackRepository { get; set; }

        public void SaveCreateOrUpdate(RackContract rackContract)
        {
            var RackDB = IRackRepository.Get(rackContract.Id);

            if (RackDB != null)
            {
                
            }
            else
            {
               RackDB =  new Rack();
               RackDB.Name = rackContract.name;
               RackDB.Code = rackContract.Code;
               RackDB.Limit = rackContract.Limit;
               RackDB.Location = rackContract.Location;
               for (int i = 0; i< rackContract.Racks.Count ; i++)
               {
                   var temp = rackContract.Racks[i];
                   RackDB.Racks = rackContract.Racks;
               }
            }
        }

    }
}
