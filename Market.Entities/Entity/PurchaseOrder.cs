using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.Entity
{
    public class PurchaseOrder: Order
    {
        public PurchaseOrder() 
        {
            PurchaseOrderItem = new List<PurchaseOrderItem>();

        }
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItem { get; set; }
    }
}
