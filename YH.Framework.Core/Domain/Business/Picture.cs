using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 图片信息
    /// </summary>
    public class Picture:BaseEntity
    {
        /// <summary>
        /// 原名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 全名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 新名称
        /// </summary>
        public string NewName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// title 属性
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// alt 属性
        /// </summary>
        public string Alt { get; set; }

        /// <summary>
        /// 目标地址
        /// </summary>
        public string Src { get; set; }
    }
}
