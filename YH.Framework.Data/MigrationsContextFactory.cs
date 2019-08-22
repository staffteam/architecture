using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Data;

namespace YH.Framework.Data
{
    public class MigrationsContextFactory : IDbContextFactory<CustomDbContext>
    {
        public CustomDbContext Create()
        {
            return new CustomDbContext("firstConnectionString");
        }
    }
}
