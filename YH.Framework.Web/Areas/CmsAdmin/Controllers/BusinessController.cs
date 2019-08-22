using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YH.Framework.Web.Core.Mvc;

namespace YH.Framework.Web.Areas.CmsAdmin.Controllers
{
    public class BusinessController : BaseController
    {
        // GET: CmsAdmin/Business
        public ActionResult Index()
        {
            return View();
        }
    }
}