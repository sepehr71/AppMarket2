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
                RackDB.Code = rackContract.Code;
                RackDB.Limit = rackContract.Limit;
                RackDB.Location = rackContract.Location;
                RackDB.Name = rackContract.name;
                RackDB.Racks = IRackRepository.Get(rackContract.RackID);
                
            }
            else
            {
               Rack rack = new Rack();
               rack.Code = rackContract.Code;
               rack.Limit = rackContract.Limit;
               rack.Location = rackContract.Location;
               rack.Name = rackContract.name;
               rack.Racks = IRackRepository.Get(rackContract.Id);
               IRackRepository.Insert(RackDB);
            }
        }
    }
}