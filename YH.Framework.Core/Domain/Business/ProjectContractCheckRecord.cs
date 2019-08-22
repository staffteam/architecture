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
    /// 项目合同审核记录
    /// </summary>
    public class ProjectContractCheckRecord:BaseEntity
    {
        /// <summary>
        /// 合同编号
        /// </summary>
        public int ContractID { get; set; }

        /// <summary>
        /// 合同
        /// </summary>
        public virtual ProjectContract Contract { get; set; }

        /// <summary>
        /// 审核人编号
        /// </summary>
        public int AuditorID { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public virtual User Auditor { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
