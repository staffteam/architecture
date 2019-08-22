using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 字典表
    /// </summary>
    public class Dictionary:BaseEntity
    {
        public Dictionary()
        {
            this.Childrens = new List<Dictionary>();
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 区别码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 所属父级编号
        /// </summary>
        public int ParentID { get; set; }

        /// <summary>
        /// 所属父级
        /// </summary>
        public virtual Dictionary Parent { get; set; }

        
        /// <summary>
        /// 子级列表
        /// </summary>
        public virtual ICollection<Dictionary> Childrens { get; set; }
    }
}
