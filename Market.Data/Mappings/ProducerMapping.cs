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
   public class ProducerMapping : IAutoMappingOverride<Producer>
    {
        public void Override(AutoMapping<Producer> mapping)
        {
            //mapping.Id(x => x.Id);
            //mapping.HasManyToMany<Movie>(x => x.Movies).Cascade.All().Table("MovieProducer");
        }
    }
}
