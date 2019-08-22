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
    /// 项目相关审核记录
    /// </summary>
    public class ProjectCheckRecord:BaseEntity
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// 项目
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// 审核人编号
        /// </summary>
        public int? AuditorID { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public User Auditor { get; set; }

        /// <summary>
        /// 提交审核时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime ModifiedTime { get; set; }
    }
}
