using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 项目工作群组消息记录
    /// </summary>
    public class ProjectWorkGroupMsgRecord:BaseEntity
    {
        /// <summary>
        /// 消息编号
        /// </summary>
        public int MessageID { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public virtual ProjectWorkGroupMsg Message { get; set; }

        /// <summary>
        /// 所属会员编号
        /// </summary>
        public int MemberID { get; set; }

        /// <summary>
        /// 所属会员
        /// </summary>
        public virtual Member Member { get; set; }
    }
}
