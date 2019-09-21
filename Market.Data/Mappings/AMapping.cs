using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Market.Entities.Entity;

namespace Market.Data.Mappings
{
   public class AMapping : IAutoMappingOverride<A>
    {
        public void Override(AutoMapping<A> mapping)
        {
            mapping.Id(x => x.Id);
            mapping.References(x => x.b1);
        }
    }
}
