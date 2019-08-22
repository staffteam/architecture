using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YH.Framework.Core.Domain.Navigates;
using YH.Framework.Core.Domain.Security;
using YH.Framework.Core.Infrastructure;
using YH.Framework.Core.Paging;
using YH.Framework.Service.Navigates;
using YH.Framework.Service.Security;
using YH.Framework.Service.Users;
using YH.Framework.Web.Areas.CmsAdmin.Models.Users;
using YH.Framework.Web.Core.Mvc;
using YH.Framework.Web.Core.Security;

namespace YH.Framework.Web.Areas.CmsAdmin.Controllers
{
    [ActionAuthorize]
    public class PermissionController : BaseController
    {
        private readonly IConfigurationProvider mapperConfigProvider;

        private readonly IPermissionService permissionService;

        private readonly INavigateService navigateService;

        private readonly IMapper mapper;

        public PermissionController(IPermissionService permissionService, INavigateService navigateService, IConfigurationProvider mapperConfigProvider)
        {
            this.permissionService = permissionService;
            this.navigateService = navigateService;
            this.mapperConfigProvider = mapperConfigProvider;
            this.mapper = mapperConfigProvider.CreateMapper();
        }
        // GET: CmsAdmin/Permission
        public ActionResult Index(string keyword, int page = 1)
        {
            IPagedList<Permission> permissions = permissionService.GetPermissions(keyword, page, 15);
            var permissionModels = mapper.Map<IEnumerable<Permission>, IEnumerable<PermissionModel>>(permissions);
            var viewModel = new StaticPagedList<PermissionModel>(permissionModels, permissions.GetMetaData());
            return Request.IsAjaxRequest() ? (ActionResult)Json(viewModel,JsonRequestBehavior.AllowGet) : View(viewModel);
        }

        public ActionResult Create()
        {
            ViewBag.Category = new SelectList(navigateService.GetNavigates(),"Name","Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModelStateValidFilter]
        public ActionResult Create(PermissionModel model)
        {
            if (ModelState.IsValid)
            {
                permissionService.CreatePermission(mapper.Map<Permission>(model));
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(navigateService.GetNavigates(), "Name", "Name");
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            Permission permission = permissionService.GetPermission(id);
            List<Navigate> navigates = navigateService.GetNavigates();
            ViewBag.Category = navigates.Select(n=>new SelectListItem
            {
                Value = n.Name,
                Text = n.Name,
                Selected = permission.Category==n.Name
            });
            return View(mapper.Map<Permission,PermissionModel>(permission,opts=> {
                opts.AfterMap((src, dest) =>
                {
                    dest.Category = src.Category;
                });
            }));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModelStateValidFilter]
        public ActionResult Edit(PermissionModel model)
        {
            Permission permission = permissionService.GetPermission(model.ID);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PermissionModel, Permission>().ForMember(m => m.Implies, p => p.Ignore()));
            config.CreateMapper().Map(model, permission);

            if (permission.Category != permission.Category)
            {
                permission.Category = model.Category;
            }
            permissionService.UpdatePermission(mapper.Map(model, permission));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            permissionService.DeletePermission(permissionService.GetPermission(id));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Deletes(int[] check)
        {
            check = check ?? new int[0];
            Array.ForEach(check, id => permissionService.DeletePermission(id));
            return RedirectToAction("Index");
        }
    }
}