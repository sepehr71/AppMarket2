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
    public class ItemService  
    {
        public IItemRepository IItemRepository { get; set; }
        public void SaveCreateOrUpdate(ItemContract ItemContract)
        {
            var item = IItemRepository.Get(ItemContract.Id);

            if (item!=null)
            {
                item.Code = ItemContract.Code;
                item.Name = ItemContract.Name;
                item.Unit = ItemContract.Unit;
                IItemRepository.Update(item);
            }

            else
            {
                item=new Item();
                item.Code = ItemContract.Code;
                item.Name = ItemContract.Name;
                item.Unit = ItemContract.Unit;
                IItemRepository.Insert(item);
                
            }
        } 
    }
}
