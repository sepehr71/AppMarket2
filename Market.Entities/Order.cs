using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities
{
    public abstract class Order
    {
        public Order()
        {
            //OrderItem = new List<OrderItem>();
            Id = new Guid();
        } 
        public virtual Guid Id { get; set; }
        public virtual int Code { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual string Title { get; set; }


        //public virtual ICollection<OrderItem> OrderItem { get; set; }

    }

}
