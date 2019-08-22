using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 企业认证信息
    /// </summary>
    public class EnterpriseAuthInfo:BaseEntity
    {
        /// <summary>
        /// 企业名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 所在地区
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 营业执照
        /// </summary>
        public string BusinessLicense { get; set; }

        /// <summary>
        /// 联系人手机号码
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 联系人邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 所属会员编号
        /// </summary>
        public int MemberID { get; set; }

        /// <summary>
        /// 所属会员
        /// </summary>
        public virtual Member Member { get; set; }
    }
}
