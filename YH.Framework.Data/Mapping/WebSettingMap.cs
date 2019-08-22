using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Business;

namespace YH.Framework.Data.Mapping
{
    public class WebSettingMap:EntityTypeConfiguration<WebSetting>
    {
        public WebSettingMap()
        {
            this.HasKey(t => t.ID);
            this.Property(t => t.Name).IsOptional().HasMaxLength(50);
            this.Property(t => t.En_Name).IsOptional().HasMaxLength(50);
            this.Property(t => t.Slogan).IsOptional().HasMaxLength(128);
            this.Property(t => t.Filing).IsOptional().HasMaxLength(128);
            this.Property(t => t.PubFiling).IsOptional().HasMaxLength(128);
            this.Property(t => t.DomianName).IsOptional().HasMaxLength(50);
            this.Property(t => t.SeoWords).IsOptional().HasMaxLength(256);
            this.Property(t => t.SeoDesc).IsOptional().HasMaxLength(500);
            this.Property(t => t.ServiceTel).IsOptional().HasMaxLength(128);
            //this.Property(t => t.Address).IsOptional().HasMaxLength(50);
            //this.Property(t => t.Email).IsOptional().HasMaxLength(50);
            //this.Property(t => t.WeChat).IsOptional().HasMaxLength(50);
            //this.Property(t => t.QQ).IsOptional().HasMaxLength(50);
            this.Property(t => t.CopyRight).IsOptional().HasMaxLength(50);
            this.Property(t => t.Powered).IsOptional().HasMaxLength(50);
            this.Property(t => t.PoweredUrl).IsOptional().HasMaxLength(50);
            this.Property(t=>t.Logo).IsOptional().HasMaxLength(256);
            this.Property(t => t.WeChatCode).IsOptional().HasMaxLength(256);
        }
    }
}
