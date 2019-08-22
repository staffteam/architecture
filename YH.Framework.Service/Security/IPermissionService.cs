using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Domain.Security;
using YH.Framework.Core.Domain.Users;
using YH.Framework.Core.Paging;

namespace YH.Framework.Service.Security
{
    public interface IPermissionService
    {
        IEnumerable<Permission> GetPermissions();

        IEnumerable<Permission> GetPermissionsForTracking();

        Permission GetPermission(int id);

        IPagedList<Permission> GetPermissions(string keyword, int pageNumber, int pageSize);

        void CreatePermission(Permission permission);

        void UpdatePermission(Permission permission);

        void DeletePermission(Permission permission);

        void DeletePermission(int id);

        bool Authorize(Permission permission);

        bool Authorize(Permission permission, User user);

        bool Authorize(string permissionName);

        bool Authorize(string permissionName, User user);
    }
}
