using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YH.Framework.Web.Core.Mvc;

namespace YH.Framework.Web.Controllers
{
    public class WebController : BaseController
    {
        //首页
        public ActionResult Home()
        {
            return View();
        }
        //进行中的项目
        public ActionResult StartProject()
        {
            return View();
        }
        //已完成的项目
        public ActionResult OverProject()
        {
            return View();
        }
        //人才库
        public ActionResult Talents()
        {
            return View();
        }
    }
}