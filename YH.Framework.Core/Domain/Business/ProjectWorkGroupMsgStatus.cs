using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 项目工作群组消息状态
    /// </summary>
    public class ProjectWorkGroupMsgStatus:BaseEntity
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
        /// 群成员编号
        /// </summary>
        public int MemberID { get; set; }

        /// <summary>
        /// 群成员
        /// </summary>
        public virtual Member Member { get; set; }

        /// <summary>
        /// 状态  1.true-已读，2.false-未读
        /// </summary>
        public bool Status { get; set; }
    }
}
