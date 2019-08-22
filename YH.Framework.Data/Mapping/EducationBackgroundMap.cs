using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Business;

namespace YH.Framework.Data.Mapping
{
    public class EducationBackgroundMap:EntityTypeConfiguration<EducationBackground>
    {
        public EducationBackgroundMap()
        {
            this.HasKey(t => t.ID);
            this.HasRequired(t => t.School);
            this.HasRequired(t => t.Major);
        }
    }
}
