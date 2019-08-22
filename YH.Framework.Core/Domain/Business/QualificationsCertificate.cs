using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 资历证书
    /// </summary>
    public class QualificationsCertificate:BaseEntity
    {
        /// <summary>
        /// 所属会员编号
        /// </summary>
        public int MemberID { get; set; }

        /// <summary>
        /// 所属会员
        /// </summary>
        public virtual Member Member { get; set; }

        /// <summary>
        /// 证书类型编号
        /// </summary>
        public int QualificationsID { get; set; }

        /// <summary>
        /// 证书类型
        /// </summary>
        public virtual Dictionary Qualifications { get; set; }

        /// <summary>
        /// 证书照片
        /// </summary>
        public virtual string QualificationsPicture { get; set; }
    }
}
