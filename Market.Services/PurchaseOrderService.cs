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
            var PurchaseOrder = IPurchaseOrderRepository.Get(purchaseOrderContract.Id);
            
            if (PurchaseOrder != null)
            {
                //PurchaseOrder.Code = purchaseOrderContract.Code;
                //PurchaseOrder.CreationDate = purchaseOrderContract.CreationDate;
                //PurchaseOrder.Title = purchaseOrderContract.Title;

                for (int i = 0; i < purchaseOrderContract.PurchaseOrderItems.Count; i++)
                {
                   var temp = purchaseOrderContract.PurchaseOrderItems[i];
                   if (PurchaseOrder.PurchaseOrderItem.Any(s => s.Id == temp.Id))
                   {
                        var indatabaseorderitem = PurchaseOrder.PurchaseOrderItem.FirstOrDefault(s => s.Id == temp.Id);
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
                   }
                }
                //if you want delete one or more item deleted
                for (int i = 0; i < purchaseOrderContract.PurchaseOrderItems.Count; i++)
                {

                }

                
                IPurchaseOrderRepository.Update(PurchaseOrder);
            }
            else
            {
                PurchaseOrder = new PurchaseOrder();
                PurchaseOrder.Code = purchaseOrderContract.Code;
                PurchaseOrder.CreationDate = purchaseOrderContract.CreationDate;
                PurchaseOrder.Title = purchaseOrderContract.Title;

                for (int i = 0; i < purchaseOrderContract.PurchaseOrderItems.Count; i++)
                {
                    var temp = purchaseOrderContract.PurchaseOrderItems[i];
                  
                        PurchaseOrderItem purchaseorderitem = new PurchaseOrderItem();
                        purchaseorderitem.NetPrice = temp.NetPrice;
                        purchaseorderitem.Quantity = temp.Quantity;
                        purchaseorderitem.TotalPrice = temp.TotalPrice;
                        purchaseorderitem.UnitPrice = temp.UnitPrice;
                        purchaseorderitem.Item = IItemRepository.Get(temp.ItemId);
                        purchaseorderitem.Rack = IRackRepository.Get(temp.RackId);
                    

                }

                IPurchaseOrderRepository.Insert(PurchaseOrder);

            }
        }
    }
}
