﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;
using YH.Framework.Core.Domain.Users;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 岗位认证审核
    /// </summary>
    public class PostAuthCheck:BaseEntity
    {
        /// <summary>
        /// 申请人编号
        /// </summary>
        public int MemberID { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        public virtual Member Member { get; set; }

        /// <summary>
        /// 审核人编号
        /// </summary>
        public int? AuditorID { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public virtual User Auditor { get; set; }

        /// <summary>
        /// 岗位编号
        /// </summary>
        public int PostSettingID { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>
        public virtual PostSetting PostSetting { get; set; }

        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? CheckTime { get; set; }
        
        /// <summary>
        /// 审核结果状态编号
        /// </summary>
        public int StatusID { get; set; }

        /// <summary>
        /// 审核结果状态
        /// </summary>
        public virtual Dictionary Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
