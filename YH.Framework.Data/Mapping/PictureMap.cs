using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Business;

namespace YH.Framework.Data.Mapping
{
    public class PictureMap:EntityTypeConfiguration<Picture>
    {
        public PictureMap()
        {
            this.HasKey(t => t.ID);
            this.Property(t => t.Name).IsOptional().HasMaxLength(128);
            this.Property(t => t.NewName).IsOptional().HasMaxLength(128);
            this.Property(t => t.FullName).IsOptional().HasMaxLength(500);
            this.Property(t => t.Description).IsOptional().HasMaxLength(500);
            this.Property(t => t.Title).IsOptional().HasMaxLength(128);
            this.Property(t => t.Alt).IsOptional().HasMaxLength(128);
            this.Property(t => t.Src).IsOptional().HasMaxLength(500);
        }
    }
}
