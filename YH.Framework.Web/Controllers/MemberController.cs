using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YH.Framework.Web.Core.Mvc;

namespace YH.Framework.Web.Controllers
{
    public class MemberController : BaseController
    {
        //账号绑定
        public ActionResult AccountBinding()
        {
            return View();
        }
        //绑定银行卡
        public ActionResult BindingBankCard()
        {
            return View();
        }
        //绑定微信
        public ActionResult BindingWeChat()
        {
            return View();
        }
        //修改邮箱
        public ActionResult EditEmail()
        {
            return View();
        }
        //修改密码
        public ActionResult EditPaddWord()
        {
            return View();
        }
        //修改手机号
        public ActionResult EditPhone()
        {
            return View();
        }
        //基本资料
        public ActionResult Info()
        {
            return View();
        }
        //系统消息
        public ActionResult Message()
        {
            return View();
        }
        //项目沟通
        public ActionResult ProjectInterflow()
        {
            return View();
        }
        //安全设置
        public ActionResult Security()
        {
            return View();
        }
    }
}