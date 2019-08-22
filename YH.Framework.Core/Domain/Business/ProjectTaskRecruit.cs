using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 项目任务招募信息
    /// </summary>
    public class ProjectTaskRecruit:BaseEntity
    {
        /// <summary>
        /// 所属任务编号
        /// </summary>
        public int ProjectTaskID { get; set; }
        /// <summary>
        /// 所属任务
        /// </summary>
        public virtual ProjectTask ProjectTask { get; set; }

        /// <summary>
        /// 抢单者编号
        /// </summary>
        public int MemberID { get; set; }

        /// <summary>
        /// 抢单者
        /// </summary>
        public virtual Member Member { get; set; }

        /// <summary>
        /// 抢单时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 人员状态编号
        /// </summary>
        public int StatusID { get; set; }

        /// <summary>
        /// 人员状态(是否在职)
        /// </summary>
        public virtual Dictionary Status { get; set; }

    }
}
