using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YH.Framework.Web.Core.Mvc;

namespace WaterMonitor.Web.Areas.CmsAdmin.Controllers
{
    public class TestController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}