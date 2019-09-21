using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities
{
    public abstract class C
    {
        public C()
        {
            Id = new Guid();
        }

        public virtual Guid Id { get; set; }
    }
}
