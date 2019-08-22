using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Business;

namespace YH.Framework.Data.Mapping
{
    public class EnterpriseAuthInfoMap:EntityTypeConfiguration<EnterpriseAuthInfo>
    {
        public EnterpriseAuthInfoMap()
        {
            HasKey(t => t.ID);
            Property(t => t.Name).IsRequired().HasMaxLength(128);
            Property(t => t.Region).HasMaxLength(128);
            Property(t => t.Address).HasMaxLength(128);
            Property(t => t.BusinessLicense).IsRequired().HasMaxLength(256);
            Property(t => t.Phone).IsRequired().HasMaxLength(11);
            Property(t => t.Email).IsRequired().HasMaxLength(50);
            HasRequired(t => t.Member);
        }
    }
}
