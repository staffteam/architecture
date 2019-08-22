using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Business;

namespace YH.Framework.Data.Mapping
{
    public class MenuMap:EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            this.HasKey(t => t.ID);
            this.Property(t=>t.Name).IsOptional().HasMaxLength(50);
            this.Property(t => t.Code).IsOptional().HasMaxLength(50);
            this.Property(t => t.Controller).IsOptional().HasMaxLength(50);
            this.Property(t => t.Action).IsOptional().HasMaxLength(50);
            this.Property(t => t.SeoWords).IsOptional().HasMaxLength(256);
            this.Property(t => t.SeoDescription).IsOptional().HasMaxLength(500);
            this.HasOptional(t => t.Parent);
            this.HasOptional(t => t.Modifier);
        }
    }
}
