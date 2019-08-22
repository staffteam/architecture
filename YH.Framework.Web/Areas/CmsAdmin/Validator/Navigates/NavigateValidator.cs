using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YH.Framework.Web.Areas.CmsAdmin.Models.Navigates;

namespace YH.Framework.Web.Areas.Validator.Navigates
{
    public class NavigateValidator: AbstractValidator<NavigateModel>
    {
        public NavigateValidator()
        {
            RuleFor(nav => nav.Name).NotNull().Length(3, 8);
            RuleFor(nav => nav.IconClassCode).NotNull();
        }
    }
}