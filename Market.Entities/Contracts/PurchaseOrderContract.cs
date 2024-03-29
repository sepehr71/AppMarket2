﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Entity;


namespace Market.Entities.Contracts
{
    public class PurchaseOrderContract
    {
        public PurchaseOrderContract()
        {
            PurchaseOrderItemsContracts = new List<PurchaseOrderItemContract>();
        }
        public Guid Id { get; set; }
        public int Code { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public IList<PurchaseOrderItemContract> PurchaseOrderItemsContracts { get; set; }

    }
}
