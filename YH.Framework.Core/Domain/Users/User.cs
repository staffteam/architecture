
using System;
using System.Collections.Generic;
using System.ComponentModel;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Users
{
    /// <summary>
    /// ϵͳ�û���Ϣ
    /// </summary>
    public partial class User : BaseEntity
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public User()
        {
            this.Roles = new List<Role>();
        }

        /// <summary>
        /// �û���
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// �û�����
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// ΢�ű��
        /// </summary>
        public string WeChatOpenID { get; set; }

        /// <summary>
        /// �Ƿ�����
        /// </summary>
        [DefaultValue(true)]
        public bool Active { get; set; }

        /// <summary>
        /// �û���ɫ
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }

        /// <summary>
        /// ��ע��Ϣ 
        /// </summary>
        public string Remark { get; set; }
    }
}
