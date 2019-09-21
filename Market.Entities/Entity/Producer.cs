using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.Entity
{
    public class Producer
    {
        public Producer()
        {
            Id = new Guid();
            Movies = new List<Movie>();
        }
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        
    }
}
