using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Business;

namespace YH.Framework.Data.Mapping
{
    public class SchoolMajorMap:EntityTypeConfiguration<SchoolMajor>
    {
        public SchoolMajorMap()
        {
            HasKey(t => t.ID);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            HasOptional(t => t.Parent);
        }
    }
}
