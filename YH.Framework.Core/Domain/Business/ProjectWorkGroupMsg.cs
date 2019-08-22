using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 项目工作群组消息
    /// </summary>
    public class ProjectWorkGroupMsg:BaseEntity
    {
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 所属群组编号
        /// </summary>
        public int WorkGroupID { get; set; }

        /// <summary>
        /// 所属群组
        /// </summary>
        public virtual ProjectWorkGroup WorkGroup { get; set; }

        /// <summary>
        /// 发送人编号
        /// </summary>
        public int SenderID { get; set; }

        /// <summary>
        /// 发送人
        /// </summary>
        public virtual Member Sender { get; set; }
    }
}
