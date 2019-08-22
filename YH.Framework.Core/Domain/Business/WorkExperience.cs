using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 工作经历
    /// </summary>
    public class WorkExperience:BaseEntity
    {
        public int MemberID { get; set; }
        /// <summary>
        /// 所属会员
        /// </summary>
        public virtual Member Member { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string PostName { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}
