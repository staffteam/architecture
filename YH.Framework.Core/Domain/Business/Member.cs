using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;

namespace YH.Framework.Core.Domain.Business
{
    /// <summary>
    /// 会员信息
    /// </summary>
    public class Member:BaseEntity
    {
        public Member()
        {
            QualificationsCertificates = new List<QualificationsCertificate>();
            EducationBackgrounds = new List<EducationBackground>();
            WorkExperiences = new List<WorkExperience>();
        }

        /// <summary>
        /// 会员账号
        /// </summary>
        public string MemberNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string HeadPortraits { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Sex { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; }

        /// <summary>
        /// 微信号
        /// </summary>
        public string WechatNo { get; set; }

        /// <summary>
        /// 微信openID
        /// </summary>
        public string WechatOpenID { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IDCardNo { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string IDCardPicture { get; set; }

        /// <summary>
        /// 岗位编号
        /// </summary>
        public int? PostID { get; set; }

        /// <summary>
        /// 认证后岗位
        /// </summary>
        public virtual Dictionary Post { get; set; }

        /// <summary>
        /// 职称编号
        /// </summary>
        public int? PostTitleID { get; set; }

        /// <summary>
        /// 职称
        /// </summary>
        public virtual Dictionary PostTitle { get; set; }

        /// <summary>
        /// 执业资格编号
        /// </summary>
        public int? PractisingCertificateID { get; set; }

        /// <summary>
        /// 执业资格
        /// </summary>
        public virtual Dictionary PractisingCertificate { get; set; }

        /// <summary>
        /// 认证类型编号
        /// </summary>
        public int? AuthTypeID { get; set; }

        /// <summary>
        /// 认证类型 - 1、个人认证，2、企业认证
        /// </summary>
        public virtual Dictionary AuthType { get; set; }

        /// <summary>
        /// 身份编号
        /// </summary>
        public int? IdentityTypeID { get; set; }

        /// <summary>
        /// 身份 - 1、在职，2、学生
        /// </summary>
        public virtual Dictionary IdentityType { get; set; }

        /// <summary>
        /// 是否允许猎头聘请
        /// </summary>
        public bool IsAllowHeadhunter { get; set; }

        /// <summary>
        /// 信誉积分
        /// </summary>
        public int RatingScore { get; set; }

        /// <summary>
        /// 省份编号
        /// </summary>
        public int? ProvinceID { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public virtual Region Province { get; set; }

        /// <summary>
        /// 城市编号
        /// </summary>
        public int? CityID { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public virtual Region City { get; set; }

        /// <summary>
        /// 区县编号
        /// </summary>
        public int? CountyID { get; set; }

        /// <summary>
        /// 区县
        /// </summary>
        public virtual Region County { get; set; }

        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegisterTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifiedTime { get; set; }


        /// <summary>
        /// 资历证书列表
        /// </summary>
        public virtual ICollection<QualificationsCertificate> QualificationsCertificates { get; set; }
        /// <summary>
        /// 教育背景列表
        /// </summary>
        public virtual ICollection<EducationBackground> EducationBackgrounds { get; set; }
        /// <summary>
        /// 工作经历列表
        /// </summary>
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }
    }
}
