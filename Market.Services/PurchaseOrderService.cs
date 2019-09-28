using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Interfaces;
using Market.Entities.Contracts;


namespace Market.Services
{
    public class PurchaseOrderService 
    {
        public IPurchaseOrderRepository IPurchaseOrderItemRepository { get; set; }

        public void SaveCreateOrUpdate(PurchaseOrderContract PurchaseOrderContract)
        {
            var PurchaseOrder = IPurchaseOrderItemRepository.Get(PurchaseOrderContract.Id);
            //var PurchaseOrder = IPurchaseOrderRepository.Get(PurchaseOrderContract.Id);
            if (PurchaseOrder != null)
            {
                PurchaseOrder.Code = PurchaseOrderContract.Code;
                PurchaseOrder.CreationDate = PurchaseOrderContract.CreationDate;
                PurchaseOrder.PurchaseOrderItem = PurchaseOrderContract.PurchaseOrderItems;
                PurchaseOrder.Title = PurchaseOrderContract.Title;
                PurchaseOrderContract(PurchaseOrder);
            }
            else
            {
                PurchaseOrder.Code = PurchaseOrderContract.Code;
                PurchaseOrder.CreationDate = PurchaseOrderContract.CreationDate;
                PurchaseOrder.PurchaseOrderItem = PurchaseOrderContract.PurchaseOrderItems;
                PurchaseOrder.Title = PurchaseOrderContract.Title;
                IPurchaseOrderItemRepository.Insert(PurchaseOrder);
            }
        }
    }
}
