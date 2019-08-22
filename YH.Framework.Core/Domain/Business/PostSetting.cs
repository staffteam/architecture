using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 岗位设置
    /// </summary>
    public class PostSetting:BaseEntity
    {
        public PostSetting()
        {
            PostAuthSettings = new List<PostAuthSetting>();
        }

        /// <summary>
        /// 岗位名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 升级所需信誉积分
        /// </summary>
        public int RatingScore { get; set; }


        /// <summary>
        /// 岗位升级规则
        /// </summary>
        public virtual ICollection<PostAuthSetting> PostAuthSettings { get; set; }
    }
}
