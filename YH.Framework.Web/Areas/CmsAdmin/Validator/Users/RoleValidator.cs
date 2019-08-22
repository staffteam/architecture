using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YH.Framework.Web.Areas.CmsAdmin.Models.Users;

namespace YH.Framework.Web.Areas.CmsAdmin.Validator.Users
{
    public class RoleValidator: AbstractValidator<RoleModel>
    {
        public RoleValidator()
        {
            RuleFor(roleModel => roleModel.Name).NotNull().Length(2,15);
        }
    }
}