using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 学校
    /// </summary>
    public class School:BaseEntity
    {
        public School()
        {
            Majors = new List<SchoolMajor>();
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 专业列表
        /// </summary>
        public virtual ICollection<SchoolMajor> Majors { get; set; }
    }
}
