using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.Entity
{
    public class Movie
    {
        public Movie()
        {
            Id= new Guid();
            Producers = new List<Producer>();
        }
        public virtual Guid Id { set; get; }
        public virtual string name { set; get; }
        public virtual ICollection<Producer> Producers { set; get; }
        

    }
}
