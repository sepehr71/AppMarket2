﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.Entity
{
    public class RackItemLevel
    {
        public RackItemLevel()
        {
            Id = new Guid();
        }
        public virtual Guid Id { get; set; }
        public virtual int CurrentQuantity { get; set; }
        public virtual int InQuantity { get; set; }
        public virtual int OutQuantity { get; set; }

        public virtual Item Item { get; set; }
        public virtual Rack Rack { get; set; }

    }
}