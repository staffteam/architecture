using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Business;

namespace YH.Framework.Data.Mapping
{
    public class QualificationsCertificateMap:EntityTypeConfiguration<QualificationsCertificate>
    {
        public QualificationsCertificateMap()
        {
            HasKey(t => t.ID);
            Property(t => t.QualificationsPicture).IsRequired().HasMaxLength(256);
            HasRequired(t => t.Qualifications);
        }
    }
}
