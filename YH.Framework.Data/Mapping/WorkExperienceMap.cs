using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Business;

namespace YH.Framework.Data.Mapping
{
    public class WorkExperienceMap:EntityTypeConfiguration<WorkExperience>
    {
        public WorkExperienceMap()
        {
            HasKey(t => t.ID);
            Property(t => t.CompanyName).IsRequired().HasMaxLength(128);
            Property(t => t.PostName).IsRequired().HasMaxLength(50);
        }
    }
}
