using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 网站设置
    /// </summary>
    public class WebSetting:BaseEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 名称(英)
        /// </summary>
        public string En_Name { get; set; }

        /// <summary>
        ///短标语(中)
        /// </summary>
        public string Slogan { get; set; }

        /// <summary>
        /// 备案号
        /// </summary>
        public string Filing { get; set; }

        /// <summary>
        /// 公安备案号
        /// </summary>
        public string PubFiling { get; set; }

        /// <summary>
        /// 域名
        /// </summary>
        public string DomianName { get; set; }

        /// <summary>
        /// SEO 关键词
        /// </summary>
        public string SeoWords { get; set; }

        /// <summary>
        /// SEO 描述
        /// </summary>
        public string SeoDesc { get; set; }

        /// <summary>
        /// 服务电话
        /// </summary>
        public string ServiceTel { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        //public string Address { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        //public string Email { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        //public string WeChat { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        //public string QQ { get; set; }

        /// <summary>
        /// 版权所有
        /// </summary>
        public string CopyRight { get; set; }

        /// <summary>
        /// 技术支持
        /// </summary>
        public string Powered { get; set; }

        /// <summary>
        /// 技术支持主页
        /// </summary>
        public string PoweredUrl { get; set; }

        /// <summary>
        /// 浏览量
        /// </summary>
        public int Stat { get; set; }

        /// <summary>
        /// LOGO
        /// </summary>
        public virtual string Logo { get; set; }

        /// <summary>
        /// 微信二维码
        /// </summary>
        public virtual string WeChatCode { get; set; }
    }
}
