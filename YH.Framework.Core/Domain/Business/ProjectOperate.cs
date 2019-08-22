using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 项目操作记录
    /// </summary>
    public class ProjectOperate:BaseEntity
    {
        /// <summary>
        /// 所属项目编号
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// 所属项目
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorID { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public Member Operator { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
