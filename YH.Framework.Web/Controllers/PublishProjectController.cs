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
        public ActionResult SubmitInfoUp()
        {
            return View();
        }
        //图库
        public ActionResult SubmitInfoImg()
        {
            return View();
        }
        //平台审核
        public ActionResult Audit()
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
        //缴纳费用
        public ActionResult PayTheFees()
        {
            return View();
        }
        //招募人员
        public ActionResult Recruit()
        {
            return View();
        }
        //发布成功
        public ActionResult ReleaseSuccess()
        {
            return View();
        }
        //任务拆分
        public ActionResult TaskSplit()
        {
            return View();
        }
    }
}
