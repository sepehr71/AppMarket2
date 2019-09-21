using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.Entity
{
    public class Item
    {
        public Item()
        {
            Id = new Guid();
        }
        public virtual Guid Id { get; set; }
        public virtual int Code { get; set; }
        public virtual string Name { get; set; }
        public virtual Unit Unit { get; set; }
        
    }
}
