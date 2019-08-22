using System.Collections.Generic;
using YH.Framework.Core.Domain.Security;

namespace YH.Framework.Service.Security
{
    public interface IPermissionProvider
    {
        IEnumerable<Permission> GetPermissions();

        IEnumerable<DefaultPermission> GetDefaultPermissions();
    }
}
