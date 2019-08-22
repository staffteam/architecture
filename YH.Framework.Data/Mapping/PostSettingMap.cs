using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Business;

namespace YH.Framework.Data.Mapping.Business
{
    public class PostSettingMap:EntityTypeConfiguration<PostSetting>
    {
        public PostSettingMap()
        {
            HasKey(t => t.ID);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            HasMany(t => t.PostAuthSettings).WithRequired(t=>t.Post).WillCascadeOnDelete();
        }
    }
}
