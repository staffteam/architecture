using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;

namespace YH.Framework.Data
{
    public class CustomDbContext : DbContext, IDbContext
    {
        static CustomDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CustomDbContext>());
        }

        public CustomDbContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return this.Database.SqlQuery<TElement>(sql, parameters);
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return this.Database.ExecuteSqlCommand(sql, parameters);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // 禁用一对多级联删除
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            // 禁用多对多级联删除
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());


            base.OnModelCreating(modelBuilder);
        }

        //public System.Data.Entity.DbSet<YH.Framework.Core.Domain.Products.Product> Products { get; set; }

        object placeHolderVariable;
        public System.Data.Entity.DbSet<YH.Framework.Core.Domain.Security.Permission> Permissions { get; set; }
    }
}
