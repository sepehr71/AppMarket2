using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using Market.Entities;
using Market.Entities.Entity;

namespace Market.Data
{
    public class StoreConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            var g = typeof(BaseEntity).IsAssignableFrom(type) && !type.IsAbstract;
            return g;
            //  return type.Namespace == ("Market.Entities.Entity");
            // //ese  hala table ha ro pak kon test kon ok bud azakhir doros t bud  ok ghablesh haminoi babache haham bego baham darmoredesh brain storm konin (Tufan maghzi) agar motor nasuzundin bazam miam pishetun
        }
    }
}
