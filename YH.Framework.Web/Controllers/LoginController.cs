using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YH.Framework.Web.Core.Mvc;

namespace YH.Framework.Web.Controllers
{
    public class LoginController : BaseController
    {
        //登录
        public ActionResult Login()
        {
            return View();
        }

    }
}