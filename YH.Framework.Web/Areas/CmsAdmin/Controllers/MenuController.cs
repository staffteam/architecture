using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YH.Framework.Core.Domain.Business;
using YH.Framework.Core.Paging;
using YH.Framework.Service.Business;
using YH.Framework.Web.Core.Mvc;
using YH.Framework.Web.Core.Security;
using YH.Framework.Core.Utility;
using YH.Framework.Web.Areas.CmsAdmin.Infrastructure;
using AutoMapper.Execution;
using YH.Framework.Web.Areas.CmsAdmin.Models.Business;
using AutoMapper.QueryableExtensions;
using YH.Framework.Core.Infrastructure;

namespace YH.Framework.Web.Areas.CmsAdmin.Controllers
{
    [ActionAuthorize]
    public class MenuController : BaseController
    {
        private readonly IMenuService menuService;

        private readonly IWorkContext workContext;

        private readonly IMapper mapper;

        private readonly IConfigurationProvider mapperConfigProvider;

        public MenuController(IMenuService menuService, IWorkContext workContext, IMapper mapper,IConfigurationProvider mapperConfigProvider)
        {
            this.menuService = menuService;
            this.workContext = workContext;
            this.mapperConfigProvider = mapperConfigProvider;
            this.mapper = mapperConfigProvider.CreateMapper();
        }

        public ActionResult Index(string keyword, int page = 1)
        {
            IPagedList<Menu> menus = menuService.GetModels(keyword, page, 15);

            var menuModels = mapper.Map<IEnumerable<Menu>, IEnumerable<MenuModel>>(menus);

            var viewModel = new StaticPagedList<MenuModel>(menuModels, menus.GetMetaData());

            return View(viewModel);

            //return Request.IsAjaxRequest() ? (ActionResult)PartialView("MenuListPartial", viewModel) : View(viewModel);
        }
        
        [HttpPost]
        public ActionResult Delete(int[] check)
        {
            check = check ?? new int[0];
            Array.ForEach(check, id => menuService.DeleteModel(id));
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionAuthorize("MenuEdit")]
        public ActionResult Save(FormCollection form)
        {
            string menuSortOrderPrefix = "menu-";

            foreach (string key in form.Keys)
            {
                if (key.StartsWith(menuSortOrderPrefix) && !string.IsNullOrEmpty(form[key]) && form[key].All(c => Char.IsNumber(c)))
                {
                    var menu = menuService.GetModel(Convert.ToInt32(key.TrimStart(menuSortOrderPrefix)));
                    menu.SortOrder = Convert.ToInt32(form[key]);
                    menuService.UpdateModel(menu);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create(int? parentID = null)
        {
            ViewBag.Menus = menuService.GetModels().AsQueryable().ProjectTo<MenuModel>(mapperConfigProvider);
            ViewBag.ParentID = parentID;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuModel model)
        {
            if (ModelState.IsValid)
            {
                Menu menu = mapper.Map<MenuModel, Menu>(model);
                menu.CreatorID = workContext.CurrentUser.ID;
                menu.CreatedTime = DateTime.Now;
                menuService.CreateModel(menu);
                return RedirectToAction("Index");
            }
            ViewBag.Menus = menuService.GetModels().AsQueryable().ProjectTo<MenuModel>(mapperConfigProvider);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Menus = menuService.GetModels().AsQueryable().ProjectTo<MenuModel>(mapperConfigProvider);
            return View(mapper.Map<MenuModel>(menuService.GetModel(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MenuModel model)
        {
            if (ModelState.IsValid)
            {
                Menu menu = menuService.GetModel(model.ID);
                var config = new MapperConfiguration(cfg => cfg.CreateMap<MenuModel, Menu>().
                ForMember(m => m.CreatorID, p => p.Ignore()).
                ForMember(m => m.Creator, p => p.Ignore()).
                ForMember(m => m.CreatedTime, p => p.Ignore()));

                config.CreateMapper().Map(model, menu);
                //mapper.Map(model, menuService.GetModel(model.ID));
                menu.ModifierID = workContext.CurrentUser.ID;
                menu.ModifiedTime = DateTime.Now;
                menuService.UpdateModel(menu);
                return RedirectToAction("Index");
            }
            ViewBag.Menus = menuService.GetModels().AsQueryable().ProjectTo<MenuModel>(mapperConfigProvider);

            return View(model);
        }
    }
}