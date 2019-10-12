using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YH.Framework.Web.Core.Mvc;

namespace YH.Framework.Web.Controllers
{
    public class PublishProjectController : BaseController
    {
        //首页
        public ActionResult PublishProject()
        {
            return View();
        }
        //已发布项目
        public ActionResult Released()
        {
            return View();
        }
        //发布项目首页
        public ActionResult Publish()
        {
            return View();
        }
        //提交资料
        public ActionResult SubmitInfo()
        {
            return View();
        }
        //上传资料
        public ActionResult UpInfo()
        {
            return View();
        }
        //图库
        public ActionResult MapDepot()
        {
            return View();
        }
        //审核历史
        public ActionResult History()
        {
            return View();
        }
        //系统反馈
        public ActionResult Feedback()
        {
            return View();
        }
    }
}
