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
    public class PurchaseOrderService 
    {
        public IPurchaseOrderRepository IPurchaseOrderRepository { get; set; }
        public IItemRepository IItemRepository { get; set; }
        public IRackRepository IRackRepository { get; set; }
        public void SaveCreateOrUpdate(PurchaseOrderContract purchaseOrderContract )
        {
            var PurchaseOrderDB = IPurchaseOrderRepository.Get(purchaseOrderContract.Id);

            if (PurchaseOrderDB != null)
            {

                for (int i = 0; i < purchaseOrderContract.PurchaseOrderItemsContracts.Count; i++)
                {
                    
                    var temp = purchaseOrderContract.PurchaseOrderItemsContracts[i];

                   if (PurchaseOrderDB.PurchaseOrderItems.Any(s => s.Id == temp.Id))
                   {
                        var indatabaseorderitem = PurchaseOrderDB.PurchaseOrderItems.FirstOrDefault(s => s.Id == temp.Id);
                        indatabaseorderitem.NetPrice = temp.NetPrice;
                        indatabaseorderitem.Quantity = temp.Quantity;
                        indatabaseorderitem.TotalPrice = temp.TotalPrice;
                        indatabaseorderitem.UnitPrice = temp.UnitPrice;
                        //todo eslah behtar minevisim
                        indatabaseorderitem.Item = IItemRepository.Get(temp.ItemId);
                        indatabaseorderitem.Rack = IRackRepository.Get(temp.RackId);
                   }
                   else 
                   {
                        PurchaseOrderItem purchaseorderitem = new PurchaseOrderItem();
                        purchaseorderitem.NetPrice = temp.NetPrice;
                        purchaseorderitem.Quantity = temp.Quantity;
                        purchaseorderitem.TotalPrice = temp.TotalPrice;
                        purchaseorderitem.UnitPrice = temp.UnitPrice;
                        purchaseorderitem.Item = IItemRepository.Get(temp.ItemId);
                        purchaseorderitem.Rack = IRackRepository.Get(temp.RackId);
                        PurchaseOrderDB.PurchaseOrderItems.Add(purchaseorderitem);
                        
                   }
                }

                //if you want delete one or more to item deleted
                for (int i = 0; i < PurchaseOrderDB.PurchaseOrderItems.Count; i++)
                {
                    var temp = PurchaseOrderDB.PurchaseOrderItems[i];

                    if (purchaseOrderContract.PurchaseOrderItemsContracts.All(s => s.Id != temp.Id))
                    {
                        PurchaseOrderDB.PurchaseOrderItems.Remove(temp);
                    }
                }
                IPurchaseOrderRepository.Update(PurchaseOrderDB);
            }
            else
            {
                PurchaseOrderDB = new PurchaseOrder();
                PurchaseOrderDB.Code = purchaseOrderContract.Code;
                PurchaseOrderDB.CreationDate = purchaseOrderContract.CreationDate;
                PurchaseOrderDB.Title = purchaseOrderContract.Title;
                for (int i = 0; i < purchaseOrderContract.PurchaseOrderItemsContracts.Count; i++)
                {
                    var temp = purchaseOrderContract.PurchaseOrderItemsContracts[i];

                    PurchaseOrderItem purchaseorderitem = new PurchaseOrderItem();
                    purchaseorderitem.NetPrice = temp.NetPrice;
                    purchaseorderitem.Quantity = temp.Quantity;
                    purchaseorderitem.TotalPrice = temp.TotalPrice;
                    purchaseorderitem.UnitPrice = temp.UnitPrice;
                    purchaseorderitem.Item = IItemRepository.Get(temp.ItemId);
                    purchaseorderitem.Rack = IRackRepository.Get(temp.RackId);

                    PurchaseOrderDB.PurchaseOrderItems.Add(purchaseorderitem);
                   
                }
                IPurchaseOrderRepository.Insert(PurchaseOrderDB);

            }
        }

        public void Delete(PurchaseOrderContract purchaseOrderContract)
        {

        }
    }
}
