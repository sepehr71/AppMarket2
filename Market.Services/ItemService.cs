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
    public class ItemService  
    {
        public IItemRepository IItemRepository { get; set; }
        public void SaveCreateOrUpdate(ItemContract itemContract)
        {
            var item = IItemRepository.Get(itemContract.Id);
            if (item!=null)
            {
                item.Code = itemContract.Code;
                item.Name = itemContract.Name;
                item.Unit = itemContract.unit;
                IItemRepository.Update(item);
            }
            else
            {
                item = new Item();
                item.Code = itemContract.Code;
                item.Name = itemContract.Name;
                item.Unit = itemContract.unit;
                IItemRepository.Insert(item);
            }
        } 
    }
}