using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 项目付款明细
    /// </summary>
    public class ProjectPayDetail:BaseEntity
    {
        /// <summary>
        /// 交易流水号
        /// </summary>
        public string PayNo{ get; set; }

        /// <summary>
        /// 所属项目编号
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// 所属项目
        /// </summary>
        public virtual Project Project { get; set; }

        /// <summary>
        /// 所属阶段编号
        /// </summary>
        public int ProjectStageID { get; set; }

        /// <summary>
        /// 所属阶段
        /// </summary>
        public virtual Dictionary ProjectStage { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// 是否付款
        /// </summary>
        public bool IsPay { get; set; }

        /// <summary>
        /// 付款时间
        /// </summary>
        public DateTime? PayTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }
    }
}
