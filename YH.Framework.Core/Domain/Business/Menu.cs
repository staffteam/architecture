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
    /// 菜单信息
    /// </summary>
    public class Menu:BaseEntity
    {
        public Menu()
        {
            this.Childrens = new List<Menu>();
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
        /// 区域
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// 控制器
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// 行为
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// SEO 关键词
        /// </summary>
        public string SeoWords { get; set; }

        /// <summary>
        /// SEO 描述
        /// </summary>
        public string SeoDescription { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int SortOrder { get; set; }

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

        /// <summary>
        /// 父级编号
        /// </summary>
        public int? ParentID { get; set; }

        /// <summary>
        /// 所属父级
        /// </summary>
        public virtual Menu Parent { get; set; }
        

        /// <summary>
        /// 子级列表
        /// </summary>
        public virtual ICollection<Menu> Childrens { get; set; }
    }
}
