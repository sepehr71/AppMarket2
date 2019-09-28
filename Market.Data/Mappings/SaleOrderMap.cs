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
    public class SaleOrderMap : IAutoMappingOverride<SaleOrder>
    {
        public void Override(AutoMapping<SaleOrder> mapping)
        {
            mapping.Id(x => x.Id).GeneratedBy.Assigned();
            //mapping.Map(x => x.Code);
            //mapping.Map(x => x.CreationDate);
            //mapping.Map(x => x.Title);
            mapping.HasMany(x => x.SaleOrderItem).Cascade.All();
        }
    }
}
