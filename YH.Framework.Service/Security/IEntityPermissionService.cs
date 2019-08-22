using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Common;
using YH.Framework.Core.Domain.Security;
using YH.Framework.Core.Domain.Users;

namespace YH.Framework.Service.Security
{
    public interface IEntityPermissionService
    {
        bool Authorize<T>(T entity) where T : BaseEntity;

        bool Authorize(int roleID, string entityName, int entityID);

        void CreateEntityPermission(int roleID, string entityName, int entityID);

        void DeleteEntityPermission(int roleID, string entityName, int entityID);

        bool Authorize<T>(T entity, User user) where T : BaseEntity;
    }
}
