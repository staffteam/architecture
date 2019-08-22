using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    public class PictureDetail:BaseEntity
    {
        /// <summary>
        /// 区分码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// 关联对象编号
        /// </summary>
        public int? ParentID { get; set; }

        /// <summary>
        /// 关联所属对象
        /// </summary>
        public virtual Article Parent { get; set; }

        /// <summary>
        /// 图片编号
        /// </summary>
        public int PictureID { get; set; }

        /// <summary>
        /// 关联图片
        /// </summary>
        public virtual Picture Picture { get; set; }
    }
}
