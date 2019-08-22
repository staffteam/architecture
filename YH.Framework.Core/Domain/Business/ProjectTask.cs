using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 项目任务信息
    /// </summary>
    public class ProjectTask:BaseEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 金额比例(整数除以100)
        /// </summary>
        public int Percent { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// 可拉岗位编号
        /// </summary>
        public int PostID { get; set; }

        /// <summary>
        /// 可接岗位
        /// </summary>
        public virtual PostSetting Post { get; set; }

        /// <summary>
        /// 审核人编号
        /// </summary>
        public int AuditorID { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public virtual Member Auditor { get; set; }

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
        /// 分类编号
        /// </summary>
        public int ClassfyID { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public virtual Dictionary Classfy { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 创建人编号
        /// </summary>
        public int CreatorID { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public virtual Member Creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 修改人编号
        /// </summary>
        public int? ModifierID { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public virtual Member Modifier { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifiedTime { get; set; }
    }
}
