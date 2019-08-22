using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 教育背景
    /// </summary>
    public class EducationBackground:BaseEntity
    {
        /// <summary>
        /// 所属会员编号
        /// </summary>
        public int MemberID { get; set; }

        /// <summary>
        /// 所属会员
        /// </summary>
        public virtual Member Member { get; set; }

        /// <summary>
        /// 学校编号
        /// </summary>
        public int SchoolID { get; set; }

        /// <summary>
        /// 学校
        /// </summary>
        public virtual School School { get; set; }

        /// <summary>
        /// 专业编号
        /// </summary>
        public int MajorID { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        public virtual SchoolMajor Major { get; set; }

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
