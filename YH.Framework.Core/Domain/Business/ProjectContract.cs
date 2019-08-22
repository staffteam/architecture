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
    /// 项目合同记录
    /// </summary>
    public class ProjectContract:BaseEntity
    {
        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractNo { get; set; }

        /// <summary>
        /// 所属项目编号
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// 所属项目
        /// </summary>
        public virtual Project Project { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 状态编号
        /// </summary>
        public int StatusID { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public virtual Dictionary Status { get; set; }

        /// <summary>
        /// 创建人编号
        /// </summary>
        public int CreatorID { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public virtual User Creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }
    }
}
