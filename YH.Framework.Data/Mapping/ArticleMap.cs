using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Business;

namespace YH.Framework.Data.Mapping
{
    public class ArticleMap:EntityTypeConfiguration<Article>
    {
        public ArticleMap()
        {
            this.HasKey(t => t.ID);
            this.Property(t=>t.Title).IsOptional().HasMaxLength(256);
            this.Property(t => t.Description).IsOptional().HasMaxLength(256);
            this.Property(t => t.Content).IsOptional().HasMaxLength(256);
            this.Property(t => t.Author).IsOptional().HasMaxLength(256);
            this.Property(t => t.Code).IsOptional().HasMaxLength(20);
            this.Property(t => t.SeoWords).IsOptional().HasMaxLength(256);
            this.Property(t => t.SeoDescription).IsOptional().HasMaxLength(500);
        }
    }
}
