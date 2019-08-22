using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YH.Framework.Web.Areas.CmsAdmin.Models.Users;

namespace YH.Framework.Web.Areas.CmsAdmin.Validator.Users
{
    public class LoginValidator: AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(loginModel => loginModel.UserName).NotNull().Length(5, 20);
            RuleFor(loginModel => loginModel.Password).NotNull().Length(5, 20);
        }
    }
}