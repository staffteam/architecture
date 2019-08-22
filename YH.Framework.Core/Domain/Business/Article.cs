using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;
using YH.Framework.Core.Domain.Users;

namespace YH.Framework.Core.Domain.Business
{
    public class Article: BaseEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 区分码
        /// </summary>
        public string Code { get; set; }
        
        /// <summary>
        /// SEO 关键词
        /// </summary>
        public string SeoWords { get; set; }

        /// <summary>
        /// SEO 描述
        /// </summary>
        public string SeoDescription { get; set; }

        /// <summary>
        /// 浏览量
        /// </summary>
        public int Stat { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// 发布人编号
        /// </summary>
        public int? PublisherID { get; set; }

        /// <summary>
        /// 发布人
        /// </summary>
        public virtual User Publisher { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PublisherTime { get; set; }

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
        /// 分类编号
        /// </summary>
        public int? ClassfyID { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public virtual Dictionary Classfy { get; set; }

        /// <summary>
        /// 封面
        /// </summary>
        public string CoverPlan { get; set; }
    }
}
