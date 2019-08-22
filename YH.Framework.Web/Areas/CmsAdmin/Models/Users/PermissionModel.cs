using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace YH.Framework.Web.Areas.CmsAdmin.Models.Users
{
    [DisplayName("权限")]
    public class PermissionModel
    {

        public PermissionModel()
        {
            this.Implies = new List<PermissionModel>();
        }
        
        [DisplayName("编号")]
        public int ID { get; set; }
        
        [DisplayName("名称")]
        public string Name { get; set; }

        [DisplayName("分类")]
        public string Category { get; set; }

        [DisplayName("功能")]
        public string Description { get; set; }

        /// <summary>
        /// 隐含权限
        /// </summary>
        public IEnumerable<PermissionModel> Implies { get; set; }
    }
}