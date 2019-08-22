using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 项目工作群组文件库
    /// </summary>
    public class ProjectWorkGroupFile:BaseEntity
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 群组编号
        /// </summary>
        public int WorkGroupID { get; set; }

        /// <summary>
        /// 所属群组
        /// </summary>
        public virtual ProjectWorkGroup WorkGroup { get; set; }

        /// <summary>
        /// 上传者编号
        /// </summary>
        public int CreatorID { get; set; }

        /// <summary>
        /// 上传者
        /// </summary>
        public virtual Member Creator { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public virtual DateTime CreatedTime { get; set; }
    }
}
