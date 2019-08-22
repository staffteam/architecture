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
    /// 项目样图
    /// </summary>
    public class ProjectTemplate:BaseEntity
    {
        /// <summary>
        /// 模板编号
        /// </summary>
        public string TemplateNo { get; set; }

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

        /// <summary>
        /// 修改人编号
        /// </summary>
        public int? ModifierID { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public virtual User Modifier { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifiedTime { get; set; }
    }
}
