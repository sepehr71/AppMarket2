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
   public class Moviemapping : IAutoMappingOverride<Movie>
    {
        public void Override(AutoMapping<Movie> mapping)
        {
            mapping.Id(x => x.Id);
            mapping.HasManyToMany<Producer>(x => x.Producers).Cascade.All().Table("StoreProducer");
        }
    }
}
