using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;
using YH.Framework.Core.Domain.Users;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 岗位认证题目
    /// </summary>
    public class PostAuthTopic:BaseEntity
    {
        /// <summary>
        /// 题目名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 岗位编号
        /// </summary>
        public int PostID { get; set; }

        /// <summary>
        /// 所属岗位
        /// </summary>
        public virtual PostSetting Post { get; set; }

        /// <summary>
        /// 创建人编号
        /// </summary>
        public int CreatorID { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public virtual User Creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 修改人编号
        /// </summary>
        public int? ModifierID { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public virtual User Modifier { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifiedTime { get; set; }
    }
}
