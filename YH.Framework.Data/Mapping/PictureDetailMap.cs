using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Business;

namespace YH.Framework.Data.Mapping
{
    public class PictureDetailMap:EntityTypeConfiguration<PictureDetail>
    {
        public PictureDetailMap()
        {
            this.HasKey(t => t.ID);
            this.Property(t => t.Code).IsOptional().HasMaxLength(50);
            this.HasOptional(t => t.Parent);
        }
    }
}
