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
    public class SaleOrderService 
    {
        public ISaleOrderRepository ISaleOrderrepository { get; set; }
        public IRackRepository IRackRepository { get; set; }
        public IItemRepository ItemRepository { get; set; }

        public void SaveCreateOrUpdate(SaleOrderContract saleOrderContract)
        {
            var saleOrderDb = ISaleOrderrepository.Get(saleOrderContract.Id);

            if(saleOrderDb != null)
            {
                for (int i = 0; i<saleOrderContract.SaleOrderItemscontract.Count ; i++)
                {
                    var temp = saleOrderContract.SaleOrderItemscontract[i];

                    if (saleOrderDb.SaleOrderItem.Any(x =>x.Id==temp.Id))
                    {
                        var indatabaseorderitem = saleOrderDb.SaleOrderItem.FirstOrDefault(x => x.Id == temp.Id);
                        indatabaseorderitem.Item = ItemRepository.Get(temp.ItemId);
                        indatabaseorderitem.Rack = IRackRepository.Get(temp.RackId);
                        indatabaseorderitem.NetPrice = temp.NetPrice;
                        indatabaseorderitem.Quantity = temp.Quantity;
                        indatabaseorderitem.TotalPrice = temp.TotalPrice;
                        indatabaseorderitem.UnitPrice = temp.UnitPrice;
                    }
                    else
                    {
                      SaleOrderItem saleOrderItem = new SaleOrderItem();
                      saleOrderItem.Item = ItemRepository.Get(temp.ItemId);
                      saleOrderItem.Rack = IRackRepository.Get(temp.RackId);
                      saleOrderItem.Quantity = temp.Quantity;
                      saleOrderItem.NetPrice = temp.NetPrice;
                      saleOrderItem.TotalPrice = temp.TotalPrice;
                      saleOrderItem.UnitPrice = temp.UnitPrice;
                      saleOrderDb.SaleOrderItem.Add(saleOrderItem);
                    }
                }

                for (int i = 0; i < saleOrderDb.SaleOrderItem.Count; i++)
                {
                    var temp = saleOrderDb.SaleOrderItem[i];
                    if (saleOrderContract.SaleOrderItemscontract.All(x => x.Id != temp.Id))
                    {
                        saleOrderDb.SaleOrderItem.Remove(temp);
                    }
                }
                ISaleOrderrepository.Update(saleOrderDb);
            }
            else
            {

                saleOrderDb = new SaleOrder();
                saleOrderDb.Code = saleOrderContract.Code;
                saleOrderDb.CreationDate = saleOrderContract.CreationDate;
                saleOrderDb.Title = saleOrderContract.Title;
                SaleOrderItem saleOrderItem = new SaleOrderItem();
                for (int i = 0; i < saleOrderContract.SaleOrderItemscontract.Count; i++)
                {
                    var temp = saleOrderContract.SaleOrderItemscontract[i];

                    saleOrderItem.Item = ItemRepository.Get(temp.ItemId);
                    saleOrderItem.Rack = IRackRepository.Get(temp.RackId);
                    saleOrderItem.Quantity = temp.Quantity;
                    saleOrderItem.NetPrice = temp.NetPrice;
                    saleOrderItem.TotalPrice = temp.TotalPrice;
                    saleOrderItem.UnitPrice = temp.UnitPrice;
                    saleOrderDb.SaleOrderItem.Add(saleOrderItem);
                }
                ISaleOrderrepository.Insert(saleOrderDb);
            }
        }
    }
}
