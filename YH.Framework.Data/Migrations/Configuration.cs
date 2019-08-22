namespace YH.Framework.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using YH.Framework.Core.Domain.Navigates;
    using YH.Framework.Core.Domain.Security;
    using YH.Framework.Core.Domain.Users;

    internal sealed class Configuration : DbMigrationsConfiguration<YH.Framework.Data.CustomDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(YH.Framework.Data.CustomDbContext context)
        {
    
        }
    }
}
