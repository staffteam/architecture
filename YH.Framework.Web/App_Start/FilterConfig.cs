using System.Web.Mvc;
using YH.Framework.Web.Core.Security;

namespace YH.Framework.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new Areas.CmsAdmin.Exceptions.ExceptionHandlingAttribute());
        }
    }
}
