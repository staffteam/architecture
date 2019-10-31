using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YH.Framework.Web.Core.Mvc;

namespace YH.Framework.Web.Controllers
{
    public class IdentityController : BaseController
    {
        //身份认证
        public ActionResult IdentityEntrance()
        {
            return View();
        }
        //完善企业资料
        public ActionResult IdentityInfo()
        {
            return View();
        }
        //企业认证成功
        public ActionResult IdentitySuccess()
        {
            return View();
        }
        //完善个人资料
        public ActionResult PersonalCertificate()
        {
            return View();
        }
        //岗位认证
        public ActionResult PostTheCertification()
        {
            return View();
        }
        //专业审核
        public ActionResult Assess()
        {
            return View();
        }
    }
}
