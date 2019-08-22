using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YH.Framework.Core.Domain.Navigates;
using YH.Framework.Core.Domain.Users;
using YH.Framework.Core.Infrastructure;
using YH.Framework.Service.Navigates;
//using YH.Framework.Service.Products;
using YH.Framework.Service.Security;
using YH.Framework.Service.Users;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(YH.Framework.Web.App_Start.DataInitializer), "Start", Order = int.MaxValue)]
namespace YH.Framework.Web.App_Start
{
    public static class DataInitializer
    {
        public static void Start()
        {
            string adminUserName = "admin";
            string adminRoleName = "系统管理员";
            string adminPassword = "admin";

            var permissionProviders = ServiceContainer.ResolveAll<IPermissionProvider>();

            var codePermissions = permissionProviders.SelectMany(pp => pp.GetPermissions());

            IPermissionService permissionService = ServiceContainer.Resolve<IPermissionService>();

            var dbPermissions = permissionService.GetPermissionsForTracking().ToList();

            //向数据库添加新增的权限列表

            foreach (var codePermission in codePermissions)
            {
                var dbPermission = dbPermissions.FirstOrDefault(dbp => dbp.Name == codePermission.Name);

                if (dbPermission == null)
                {
                    permissionService.CreatePermission(codePermission);
                }
                else
                {
                    dbPermission.Category = codePermission.Category;
                    dbPermission.Name = codePermission.Name;
                    dbPermission.Description = codePermission.Description;

                    permissionService.UpdatePermission(dbPermission);
                }
            }

            //从数据库删除无效的权限列表

            dbPermissions = permissionService.GetPermissionsForTracking().ToList();

            foreach (var dbPermission in dbPermissions)
            {
                var codePermission = codePermissions.SingleOrDefault(cp => cp.Name == dbPermission.Name);

                if (codePermission == null)
                {
                    permissionService.DeletePermission(dbPermission);
                }
            }

            //创建管理员用户、角色和权限

            IRoleService roleService = ServiceContainer.Resolve<IRoleService>();

            if (roleService.GetRole(adminRoleName) == null)
            {
                roleService.CreateRole(new Role { Name = adminRoleName, Active = true });
            }

            IUserService userService = ServiceContainer.Resolve<IUserService>();

            if (userService.GetUser(adminUserName) == null)
            {
                userService.CreateUser(new User
                {
                    Name = adminUserName,
                    Active = true,
                    Password = adminPassword,
                    CreateDate = DateTime.Now,
                    Remark = adminRoleName
                });
            }

            var adminRole = roleService.GetRole(adminRoleName);
            var adminUser = userService.GetUser(adminUserName);
            adminUser.Roles.Add(adminRole);

            userService.UpdateUser(adminUser);

            dbPermissions = permissionService.GetPermissionsForTracking().ToList();

            foreach (var permission in dbPermissions)
            {
                adminRole.Permissions.Add(permission);
            }

            roleService.UpdateRole(adminRole);

            var navigateService = ServiceContainer.Resolve<INavigateService>();

            var navigates = navigateService.GetNavigates();

            if (navigates == null || !navigates.Any())
            {

                var userInfoNavigate = new Navigate
                {
                    Name = "用户信息",
                    IconClassCode = "glyphicon glyphicon-user",
                    Active = true,
                    Children = new List<Navigate>
                    {
                        new Navigate { ControllerName = "Permission", ActionName = "Index", Name = "权限管理", IconClassCode = "fa fa-fw fa-eye text-yellow", Active = true },
                        new Navigate { ControllerName = "Role", ActionName = "Index", Name = "角色管理", IconClassCode = "fa fa-group text-light-blue", Active = true },
                        new Navigate { ControllerName = "User", ActionName = "Index", Name = "用户管理", IconClassCode = "fa fa-user text-yellow", Active = true },
                        //new Navigate { ControllerName = "User", ActionName = "ChangePassword", Name = "修改密码", IconClassCode = "fa fa-key text-light-blue", Active = true }
                    }
                };

                navigateService.CreateNavigate(userInfoNavigate);

                var sysInfoNavigate = new Navigate
                {
                    Name = "系统设置",
                    IconClassCode = "glyphicon glyphicon-cog",
                    Active = true,
                    Children = new List<Navigate>
                    {
                        new Navigate { ControllerName = "Navigate", ActionName = "Index", Name = "导航管理", IconClassCode = "fa fa-list text-green", Active = true },
                        new Navigate { ControllerName = "Log", ActionName = "Index", Name = "系统日志", IconClassCode = "fa fa-envelope-o", Active = true }
                    }
                };

                navigateService.CreateNavigate(sysInfoNavigate);

                var bllServiceNavigate = new Navigate
                {
                    Name = "系统业务",
                    IconClassCode = "fa fa-cube",
                    Active = true,
                    Children = new List<Navigate>
                    {
                        new Navigate { ControllerName = "Business", ActionName = "Project", Name = "项目管理", IconClassCode = "fa fa-flask text-light-blue", Active = true },
                        new Navigate { ControllerName = "Member", ActionName = "Member", Name = "会员管理", IconClassCode = "fa fa-flask text-light-blue", Active = true },
                    }
                };

                navigateService.CreateNavigate(bllServiceNavigate);
            }

            //var productService = ServiceContainer.Resolve<IProductService>();

            //productService.CreteProduct(new Product { Name = "零度课堂C#教程", Price = 88.50 });
            //productService.CreteProduct(new Product { Name = "零度课堂EfCore教程", Price = 20.50 });
        }
    }
}