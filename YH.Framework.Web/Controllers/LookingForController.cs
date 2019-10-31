using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YH.Framework.Web.Core.Mvc;

namespace YH.Framework.Web.Controllers
{
    public class LookingForController : BaseController
    {

        //项目报名
        public ActionResult Apply()
        {
            return View();
        }
        //项目详情
        public ActionResult LookDetails()
        {
            return View();
        }
        //寻找项目首页
        public ActionResult LookingFor()
        {
            return View();
        }
        //寻找项目列表
        public ActionResult LookingForList()
        {
            return View();
        }
        //我参与的项目
        public ActionResult MyProject()
        {
            return View();
        }
        //我的任务
        public ActionResult MyTask()
        {
            return View();
        }
    }
}