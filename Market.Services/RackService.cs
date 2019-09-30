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
            var rackDB = IRackRepository.Get(RackContract.Id);

            
            if (rackDB != null)
            {
                rackDB.Code = RackContract.Code;
                rackDB.Limit = RackContract.Limit;
                rackDB.Location = RackContract.Location;
                rackDB.Name = RackContract.name; 
                for (int i = 0; i < RackContract; i++)
                {
                    var temp = RackContract.racksContract[i];
                    if (rackDB.Racks.Any(s =>s.Id == temp.Id))
                    {
                        var indatabaseracks = rackDB.Racks.FirstOrDefault(s => s.Id == temp.Id);
                        indatabaseracks.Racks = IRackRepository.Get(temp.Racks);

                    }
                    else
                    {
                        

                    }
                   
                }
                IRackRepository.Update(rackDB);
            }
            else
            {
                rackDB = new Rack();
                rackDB.Code = RackContract.Code;
                rackDB.Limit = RackContract.Limit;
                rackDB.Location = RackContract.Location;
                rackDB.Name = RackContract.name;
                rackDB.Racks = RackContract.racksContract;
                IRackRepository.Insert(rackDB);
            }
        }
    }
}
