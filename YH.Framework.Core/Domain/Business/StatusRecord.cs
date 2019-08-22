using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 状态字典
    /// </summary>
    public class StatusRecord:BaseEntity
    {
        /// <summary>
        /// 状态编号
        /// </summary>
        public int StatusID { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public virtual Dictionary Status { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// 项目
        /// </summary>
        public virtual Project Project { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }
    }
}
