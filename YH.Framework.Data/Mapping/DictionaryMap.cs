using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Business;

namespace YH.Framework.Data.Mapping
{
    public class DictionaryMap: EntityTypeConfiguration<Dictionary>
    {
        public DictionaryMap()
        {
            this.HasKey(t => t.ID);
            this.Property(t => t.Name).IsOptional().HasMaxLength(50);
            this.Property(t => t.Code).HasMaxLength(50);
        }
    }
}
