using System.Collections.Generic;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Security
{
    /// <summary>
    /// 系统控制器权限
    /// </summary>
    public partial class Permission : BaseEntity
    {
        public Permission()
        {
            this.Implies = new List<Permission>();
        }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 所属分类
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 功能名称
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 隐含权限
        /// </summary>
        public IEnumerable<Permission> Implies { get; set; }
    }
}
