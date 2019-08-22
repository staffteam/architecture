﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YH.Framework.Core.Caching;
using YH.Framework.Core.Data;
using YH.Framework.Core.Domain.Security;
using YH.Framework.Core.Domain.Users;
using YH.Framework.Core.Infrastructure;
using YH.Framework.Core.Paging;

namespace YH.Framework.Service.Security
{
    public class PermissionService : IPermissionService
    {
        private readonly IRepository<Permission> permissionRepository;

        private readonly IWorkContext workContext;

        private readonly ICacheManager cacheManager;

        private const string PermissionsCacheKey = nameof(PermissionService) + nameof(Permission);

        private const string RolePermissionCacheKeyPrefix = nameof(PermissionService) + nameof(Role) + nameof(Permission);

        public PermissionService(IRepository<Permission> permissionRepository, IWorkContext workContext, ICacheManager cacheManager)
        {
            this.workContext = workContext;
            this.permissionRepository = permissionRepository;
            this.cacheManager = cacheManager;
        }


        public IEnumerable<Permission> GetPermissionsForTracking()
        {
            return permissionRepository.Table;
        }

        public IEnumerable<Permission> GetPermissions()
        {
            return cacheManager.Get(PermissionsCacheKey, () => permissionRepository.TableNoTracking.ToList());
        }

        public IPagedList<Permission> GetPermissions(string keyword, int pageNumber, int pageSize)
        {
            var permissions = permissionRepository.Table;

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                permissions = permissions.Where(m => m.Name.Contains(keyword));
            }

            return permissions.ToPagedList(m => m.ID, pageNumber, pageSize);
        }

        protected virtual bool Authorize(string permissionName, Role role)
        {
            string cacheKey = string.Concat(RolePermissionCacheKeyPrefix, role.ID, permissionName);

            return cacheManager.Get(cacheKey, () => role.Permissions.Any(p => p.Name.Equals(permissionName, StringComparison.InvariantCultureIgnoreCase)));
        }

        public bool Authorize(Permission permission)
        {
            return Authorize(permission, workContext.CurrentUser);
        }

        public bool Authorize(Permission permission, User user)
        {
            return Authorize(permission.Name, workContext.CurrentUser);
        }

        public bool Authorize(string permissionName)
        {
            return Authorize(permissionName, workContext.CurrentUser);
        }

        public bool Authorize(string permissionName, User user)
        {
            return user.Roles.Where(role => role.Active).Any(role => Authorize(permissionName, role));
        }

        public Permission GetPermission(int id)
        {
            return permissionRepository.GetById(id);
        }

        public void CreatePermission(Permission permission)
        {
            permissionRepository.Insert(permission);
        }

        public void UpdatePermission(Permission permission)
        {
            permissionRepository.Update(permission);
        }

        public void DeletePermission(Permission permission)
        {
            permissionRepository.Delete(permission);
        }

        public void DeletePermission(int id)
        {
            DeletePermission(permissionRepository.GetById(id));
        }
    }
}
