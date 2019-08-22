using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 银行卡
    /// </summary>
    public class BankCard:BaseEntity
    {
        /// <summary>
        /// 银行卡号
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 预留手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 银行卡封面
        /// </summary>
        public string CoverPlan { get; set; }

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
