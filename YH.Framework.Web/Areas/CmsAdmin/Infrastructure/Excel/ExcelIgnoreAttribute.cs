using System;

namespace YH.Framework.Web.Areas.CmsAdmin.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class ExcelIgnoreAttribute : Attribute
    {

    }
}
