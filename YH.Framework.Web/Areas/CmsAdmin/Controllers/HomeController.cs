using System.Web.Mvc;

namespace YH.Framework.Web.Areas.CmsAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}