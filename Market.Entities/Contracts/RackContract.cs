using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Entity;

namespace Market.Entities.Contracts
{
    public class RackContract
    {

        public RackContract()
        {
            
        }

        public Guid Id { get; set; }
        public string name { get; set; }
        public int Code { get; set; }
        public int Limit { get; set; }
        public string Location { get; set; }
        public Guid RackID { get; set; }
    }
}
