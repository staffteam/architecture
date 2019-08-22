using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using YH.Framework.Core.Domain.Common;
using YH.Framework.Web.Areas.CmsAdmin.Models.Users;

namespace YH.Framework.Web.Areas.CmsAdmin.Models.Business
{
    [DisplayName("菜单")]
    public class MenuModel:ICreatedTime
    {
        public MenuModel()
        {
            this.Childrens = new List<MenuModel>();
        }

        [DisplayName("编号")]
        public int ID { get; set; }

        [DisplayName("名称(中)")]
        public string Name { get; set; }

        [DisplayName("名称(英)")]
        public string En_Name { get; set; }

        [DisplayName("菜单编码")]
        public string Code { get; set; }

        [DisplayName("控制器")]
        public string Controller { get; set; }

        [DisplayName("行为")]
        public string Action { get; set; }

        [DisplayName("Seo关键词")]
        public string SeoWords { get; set; }

        [DisplayName("Seo描述")]
        public string SeoDescription { get; set; }

        [DisplayName("排序号")]
        public int SortOrder { get; set; }

        [DisplayName("创建人编号")]
        public int CreatorID { get; set; }

        [DisplayName("创建人")]
        public UserModel Creator { get; set; }

        [DisplayName("创建时间")]
        public DateTime CreatedTime { get; set; }

        [DisplayName("修改人编号")]
        public int? ModifierID { get; set; }

        [DisplayName("修改人")]
        public UserModel Modifier { get; set; }

        [DisplayName("修改时间")]
        public DateTime? ModifiedTime { get; set; }

        [DisplayName("父级菜单编号")]
        public int? ParentID { get; set; }

        [DisplayName("父级菜单")]
        public MenuModel Parent { get; set; }

        [DisplayName("子级菜单")]
        public virtual IEnumerable<MenuModel> Childrens { get; set; }
    }
}