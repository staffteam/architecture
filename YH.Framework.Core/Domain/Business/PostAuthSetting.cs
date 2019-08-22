using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 岗位认证设置
    /// </summary>
    public class PostAuthSetting:BaseEntity
    {
        /// <summary>
        /// 岗位编号
        /// </summary>
        public int PostID { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>
        public virtual PostSetting Post { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        public int TaskTypeID { get; set; }

        /// <summary>
        /// 任务类型
        /// </summary>
        public virtual Dictionary TaskType { get; set; }

        /// <summary>
        /// 升级所需任务数量
        /// </summary>
        public int TaskCount { get; set; }
    }
}
