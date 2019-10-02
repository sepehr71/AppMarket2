using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Market.Entities;
using Market.Entities.Entity;


namespace Market.Data.Mappings
{
    public class RackMap : IAutoMappingOverride<Rack>
    {
        public void Override(AutoMapping<Rack> mapping)
        {
            mapping.Id(x => x.Id).GeneratedBy.Assigned();
            //mapping.Map(x => x.Name);
            //mapping.Map(x => x.Code);
            //mapping.Map(x => x.Limit);
            //mapping.Map(x => x.Location);
            mapping.References(x => x.Racks);
        }
    }
}
