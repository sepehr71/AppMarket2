using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Interfaces;
using Market.Entities.Contracts;


namespace Market.Services
{
    public class SaleOrderService 
    {
        public ISaleOrderRepository ISaleOrderrepository { get; set; }

        public void SaveCreateOrUpdate(SaleOrderContract SaleOrderContract)
        {
            var SaleOrder = ISaleOrderrepository.Get(SaleOrderContract.Id)

            if(SaleOrder != null)
            {
                SaleOrder.Code = SaleOrderContract.Code;
                SaleOrder.CreationDate = SaleOrderContract.CreationDate;
                SaleOrder.SaleOrderItem = SaleOrderContract.SaleOrderItems;
                SaleOrder.Title = SaleOrderContract.Title;
                ISaleOrderrepository.Update(SaleOrder);
            }
            else
            {
                SaleOrder.Code = SaleOrderContract.Code;
                SaleOrder.CreationDate = SaleOrderContract.CreationDate;
                SaleOrder.SaleOrderItem = SaleOrderContract.SaleOrderItems;
                SaleOrder.Title = SaleOrderContract.Title;
                ISaleOrderrepository.Insert(SaleOrder);
            }
        }
    }
}
