﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.Entity
{
    public class Item:BaseEntity
    {
        public Item()
        {
           
        }
        
        public virtual int Code { get; set; }
        public virtual string Name { get; set; }
        public virtual Unit Unit { get; set; }
        
    }
    public enum Unit
    {
        Kilo,
        Meter,
        Number,
    }
}
