//using System;
//using System.Collections.Generic;
//using System.Data.Entity.ModelConfiguration;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using YH.Framework.Core.Domain.Products;

//namespace YH.Framework.Data.Mapping
//{
//    public class ProductMap: EntityTypeConfiguration<Product>
//    {
//        public ProductMap()
//        {
//            this.HasKey(t=>t.ID);

//            this.Property(t => t.Name).IsRequired().HasMaxLength(50);
//        }
//    }
//}
