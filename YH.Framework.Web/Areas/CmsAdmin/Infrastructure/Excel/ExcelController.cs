using System.Collections.Generic;
using System.Web.Mvc;
using YH.Framework.Web.Core.Mvc;

namespace YH.Framework.Web.Areas.CmsAdmin.Infrastructure
{
    public class ExcelController : BaseController
    {
        public ExcelFileResult<T> Excel<T>(IEnumerable<T> model) where T : class
        {
            return new ExcelFileResult<T>(model);
        }

        public ExcelFileResult<T> Excel<T>(IEnumerable<T> model, string fileName) where T : class
        {
            return new ExcelFileResult<T>(model, fileName);
        }
    }
}
