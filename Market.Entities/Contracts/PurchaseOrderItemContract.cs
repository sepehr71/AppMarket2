﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Entity;

namespace Market.Entities.Contracts
{
    public class PurchaseOrderItemContract
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public Guid RackId { get; set; }
        public decimal NetPrice { get; set; }
        public  int Quantity { get; set; }
        public  decimal TotalPrice { get; set; }
        public  decimal UnitPrice { get; set; }
    }
}
