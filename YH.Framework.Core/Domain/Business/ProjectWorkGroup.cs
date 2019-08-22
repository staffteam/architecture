using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 项目工作群组
    /// </summary>
    public class ProjectWorkGroup:BaseEntity
    {
        /// <summary>
        /// 群组编号
        /// </summary>
        public string GroupNo { get; set; }

        /// <summary>
        /// 群组名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 所属项目编号
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// 所属项目
        /// </summary>
        public virtual Project Project { get; set; }
    }
}
