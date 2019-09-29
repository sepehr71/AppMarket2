using Market.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Contracts;
using Market.Entities.Entity;

namespace Market.Services
{
    public class RackService 
    {
        /// <summary>
        ///  niaz be eslah darad
        /// </summary>
        public IRackRepository IRackRepository { get; set; }
        public void SaveCreateOrUpdate(RackContract RackContract)
        {
            var rack = IRackRepository.Get(RackContract.Id);

                if(rack !=null)
                {
                    rack.Code = RackContract.Code;
                    rack.Limit = RackContract.Limit;
                    rack.Location = RackContract.Location;
                    rack.Name = RackContract.name;
                    rack.Racks = RackContract.racks;
                    IRackRepository.Update(rack);
                }
                else
                {
                    rack = new Rack();
                    rack.Code = RackContract.Code;
                    rack.Limit = RackContract.Limit;
                    rack.Location = RackContract.Location;
                    rack.Name = RackContract.name;
                    rack.Racks = RackContract.racks;
                    IRackRepository.Insert(rack);
                }
        }
    }
}
