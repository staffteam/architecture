using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 项目相关成果
    /// </summary>
    public class ProjectResult:BaseEntity
    {
        public ProjectResult()
        {
            this.StatusRecords = new List<StatusRecord>();
        }

        /// <summary>
        /// 所属项目编号
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// 所属项目
        /// </summary>
        public virtual Project Project { get; set; }

        /// <summary>
        /// 所属任务编号
        /// </summary>
        public int ProjectTaskID { get; set; }

        /// <summary>
        /// 所属任务
        /// </summary>
        public virtual ProjectTask ProjectTask { get; set; }

        /// <summary>
        /// 附件路径
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 状态编号
        /// </summary>
        public int StatusID { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public virtual Dictionary Status { get; set; }

        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime CreatedTime { get; set; }


        /// <summary>
        /// 状态变动记录列表
        /// </summary>
        public virtual ICollection<StatusRecord> StatusRecords { get; set; }
    }
}
