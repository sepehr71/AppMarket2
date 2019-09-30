using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Contracts;

namespace Market.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            PurchaseOrderContract pc = new PurchaseOrderContract();
            pc.Code = 545;
            pc.CreationDate = DateTime.Now;
            PurchaseOrderItemContract pco = new PurchaseOrderItemContract();
            pco.NetPrice = 2;
            pco.Quantity = 3;
            pco.RackId = new Guid();
            pco.ItemId= new Guid();
            pco.UnitPrice = 9;
            pco.Id=new Guid();
            pco.TotalPrice = 9879;
            pc.PurchaseOrderItemsContracts.Add(pco);
            
        }
    }
}
