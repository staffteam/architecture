using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 地区信息
    /// </summary>
    public class Region:BaseEntity
    {
        public Region()
        {
            this.Chidrens = new List<Region>();
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父级编号
        /// </summary>
        public int ParentID { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        public virtual Region Parent { get; set; }


        /// <summary>
        /// 子级列表
        /// </summary>
        public virtual ICollection<Region> Chidrens { get; set; }
    }
}
