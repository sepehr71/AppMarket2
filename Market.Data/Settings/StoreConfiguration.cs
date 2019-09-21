using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using Market.Entities;

namespace Market.Data
{
    public class StoreConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            //return type.BaseType == typeof(BaseClass);
            return type.Namespace == ("Market.Entities.Entity");
        }
    }
}
