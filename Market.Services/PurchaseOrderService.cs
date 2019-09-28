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
        public PurchaseOrderService()
        {
            IPurchaseOrderItemRepository = new List<IPurchaseOrderItemRepository>();
        }
        public IPurchaseOrderRepository IPurchaseOrderRepository { get; set; }
        public List<IPurchaseOrderItemRepository> IPurchaseOrderItemRepository { get; set; }

        public void SaveCreateOrUpdate(PurchaseOrderContract PurchaseOrderContract)
        {
            var PurchaseOrder = IPurchaseOrderRepository.Get(PurchaseOrderContract.Id);
            
            if (PurchaseOrder != null)
            {
                PurchaseOrder.Code = PurchaseOrderContract.Code;
                PurchaseOrder.CreationDate = PurchaseOrderContract.CreationDate;
              //  PurchaseOrder.PurchaseOrderItem = IPurchaseOrderItemRepository
                PurchaseOrder.Title = PurchaseOrderContract.Title;
                IPurchaseOrderRepository.Update(PurchaseOrder);
            }
            else
            {
                PurchaseOrder.Code = PurchaseOrderContract.Code;
                PurchaseOrder.CreationDate = PurchaseOrderContract.CreationDate;
                PurchaseOrder.PurchaseOrderItem = PurchaseOrderContract.PurchaseOrderItems;
                PurchaseOrder.Title = PurchaseOrderContract.Title;
               // IPurchaseOrderItemRepository.Insert(PurchaseOrder);
            }
        }
    }
}
