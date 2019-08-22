using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 项目信息
    /// </summary>
    public class Project:BaseEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 规模
        /// </summary>
        public decimal Scale { get; set; }

        /// <summary>
        /// 预算
        /// </summary>
        public decimal Budget { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 分类编号
        /// </summary>
        public int ClassfyID { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public virtual Dictionary Classfy { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 发布人编号
        /// </summary>
        public int CreatorID { get; set; }

        /// <summary>
        /// 发布人
        /// </summary>
        public virtual Member Creator { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? PublisherTime { get; set; }
    }
}
