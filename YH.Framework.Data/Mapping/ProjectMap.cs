using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Business;

namespace YH.Framework.Data.Mapping
{
    public class ProjectMap:EntityTypeConfiguration<Project>
    {
        public ProjectMap()
        {
            HasKey(t => t.ID);
            Property(t => t.Name).IsRequired().HasMaxLength(128);
            Property(t => t.Budget).HasPrecision(18,2);
            Property(t => t.Address).HasMaxLength(256);
            Property(t => t.Description).IsMaxLength();
        }
    }
}
