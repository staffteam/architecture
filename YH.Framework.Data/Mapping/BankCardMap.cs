using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Business;

namespace YH.Framework.Data.Mapping
{
    public class BankCardMap:EntityTypeConfiguration<BankCard>
    {
        public BankCardMap()
        {
            this.HasKey(t => t.ID);
            this.Property(t => t.CardNo).IsRequired().HasMaxLength(20);
            this.Property(t => t.Phone).IsRequired().HasMaxLength(11);
            this.Property(t => t.BankName).HasMaxLength(50);
            this.Property(t => t.CoverPlan).IsOptional().HasMaxLength(256);
            this.Property(t => t.BankName).HasMaxLength(50);
            this.HasRequired(t => t.Member);
        }
    }
}
