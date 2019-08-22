using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Business;

namespace YH.Framework.Data.Mapping
{
    public class PostAuthSettingMap:EntityTypeConfiguration<PostAuthSetting>
    {
        public PostAuthSettingMap()
        {
            HasKey(t => t.ID);
            HasRequired(t => t.TaskType);
        }
    }
}
