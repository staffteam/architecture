using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YH.Framework.Web.Areas.CmsAdmin.Models.Business;

namespace YH.Framework.Web.Areas.CmsAdmin.Validator.Business
{
    public class MenuValidator: AbstractValidator<MenuModel>
    {
        public MenuValidator()
        {
            RuleFor(t => t.Name).NotNull().Length(0, 20);
            RuleFor(t => t.En_Name).NotNull().Length(0, 20);
            RuleFor(t => t.Code).NotNull().Length(0, 20);
            RuleFor(t => t.Controller).NotNull().Length(0, 50);
            RuleFor(t => t.Action).NotNull().Length(0, 50);
            RuleFor(t => t.SeoWords).NotNull().Length(0, 256);
            RuleFor(t => t.SeoDescription).NotNull().Length(0, 500);
            RuleFor(t => t.SortOrder).GreaterThanOrEqualTo(0);
        }
    }
}