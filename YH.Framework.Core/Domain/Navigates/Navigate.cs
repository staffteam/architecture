using System.Collections.Generic;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Navigates
{
    /// <summary>
    /// �˵�����
    /// </summary>
    public partial class Navigate : BaseEntity
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public Navigate()
        {
            this.Children = new List<Navigate>();
        }

        /// <summary>
        /// ����������
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// ��Ϊ����
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ����ͼ��
        /// </summary>
        public string IconClassCode { get; set; }

        /// <summary>
        /// ����ͼ����ɫ
        /// </summary>
        public string IconColorClassCode { get; set; }

        /// <summary>
        /// �����������
        /// </summary>
        public int? ParentID { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public Navigate Parent { get; set; }

        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// ȫ���Ӳ˵�
        /// </summary>
        public virtual ICollection<Navigate> Children { get; set; }
    }
}
