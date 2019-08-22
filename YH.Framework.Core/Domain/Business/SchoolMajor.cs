using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    public class SchoolMajor:BaseEntity
    {
        public SchoolMajor()
        {
            this.Childrens = new List<SchoolMajor>();
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父级编号
        /// </summary>
        public int? ParentID { get; set; }

        /// <summary>
        /// 所属父级
        /// </summary>
        public virtual SchoolMajor Parent { get; set; }


        /// <summary>
        /// 子级列表
        /// </summary>
        public virtual ICollection<SchoolMajor> Childrens { get; set; }
    }
}
