using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YH.Framework.Web.Core.Mvc;

namespace YH.Framework.Web.Controllers
{
    public class NoticeController : BaseController
    {

        public ActionResult NoticeDetails()
        {
            return View();
        }
    }
}