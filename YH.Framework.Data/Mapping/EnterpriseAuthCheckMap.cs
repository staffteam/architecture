using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Business;

namespace YH.Framework.Data.Mapping
{
    public class EnterpriseAuthCheckMap:EntityTypeConfiguration<EnterpriseAuthCheck>
    {
        public EnterpriseAuthCheckMap()
        {
            HasKey(t => t.ID);
            Property(t => t.Remark).HasMaxLength(500);
            HasRequired(t => t.Member);
            HasOptional(t => t.Auditor);
            HasRequired(t => t.Status);
        }
    }
}
