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
    public class RackItemLevelService 
    {
        public IRackItemLevelRepository IRackItemLevelRepository { get; set; }
        public IItemRepository IItemRepository { get; set; }
        public IRackRepository IRackRepository { get; set; }

        public void SaveCreateOrUpdate(RackItemLevelContract rackItemLevelContract)
        {
            var rackitemlevel = IRackItemLevelRepository.Get(rackItemLevelContract.Id);
            if(rackitemlevel != null)
            {
                rackitemlevel.CurrentQuantity = rackItemLevelContract.CurrentQuantity;
                rackitemlevel.InQuantity = rackItemLevelContract.InQuantity;
                rackitemlevel.Item = IItemRepository.Get(rackItemLevelContract.ItemId);
                rackitemlevel.Racks = IRackRepository.Get(rackItemLevelContract.RackId);
                rackitemlevel.OutQuantity = rackItemLevelContract.OutQuantity;
                IRackItemLevelRepository.Update(rackitemlevel);
            }
            else
            {
                rackitemlevel = new RackItemLevel();
                rackitemlevel.CurrentQuantity = rackItemLevelContract.CurrentQuantity;
                rackitemlevel.InQuantity = rackItemLevelContract.InQuantity;
                rackitemlevel.Item = IItemRepository.Get(rackItemLevelContract.ItemId);
                rackitemlevel.Racks = IRackRepository.Get(rackItemLevelContract.RackId);
                rackitemlevel.OutQuantity = rackItemLevelContract.OutQuantity;
               
                IRackItemLevelRepository.Insert(rackitemlevel);
            }
        }
       
    }
}