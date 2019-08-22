using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Business;

namespace YH.Framework.Data.Mapping
{
    public class SchoolMap:EntityTypeConfiguration<School>
    {
        public SchoolMap()
        {
            this.HasKey(t => t.ID);
            this.Property(t => t.Name).IsRequired().HasMaxLength(128);
            this.HasMany(t => t.Majors).WithOptional();
        }
    }
}
