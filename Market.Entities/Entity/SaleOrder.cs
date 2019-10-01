using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.Entity
{
    public class SaleOrder : Order
    {
        public SaleOrder() 
        {
            SaleOrderItem = new List<SaleOrderItem>();
        }

        public virtual List<SaleOrderItem> SaleOrderItem { get; set; }
    }
}
