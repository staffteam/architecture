using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Business;

namespace YH.Framework.Data.Mapping
{
    public class MemberMap:EntityTypeConfiguration<Member>
    {
        public MemberMap()
        {
            HasKey(t => t.ID);
            Property(t => t.MemberNo).HasMaxLength(10);
            Property(t => t.Name).HasMaxLength(50);
            Property(t => t.Nickname).HasMaxLength(20);
            Property(t => t.Password).HasMaxLength(50);
            Property(t => t.HeadPortraits).HasMaxLength(256);
            Property(t => t.Phone).HasMaxLength(50);
            Property(t => t.Telephone).HasMaxLength(50);
            Property(t => t.QQ).HasMaxLength(50);
            Property(t => t.WechatNo).HasMaxLength(50);
            Property(t => t.WechatOpenID).HasMaxLength(50);
            Property(t => t.Email).HasMaxLength(128);
            Property(t => t.IDCardNo).HasMaxLength(18);
            Property(t => t.IDCardPicture).HasMaxLength(256);
            Property(t => t.Street).HasMaxLength(128);
            HasMany(t => t.QualificationsCertificates).WithRequired(t=>t.Member).HasForeignKey(t => t.MemberID).WillCascadeOnDelete();
            HasMany(t => t.EducationBackgrounds).WithRequired(t=>t.Member).HasForeignKey(t => t.MemberID).WillCascadeOnDelete();
            HasMany(t => t.WorkExperiences).WithRequired(t=>t.Member).HasForeignKey(t => t.MemberID).WillCascadeOnDelete();
        }
    }
}
