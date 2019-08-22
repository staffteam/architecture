using FluentValidation;
using YH.Framework.Web.Areas.CmsAdmin.Models;
using YH.Framework.Web.Areas.CmsAdmin.Models.Configuration;

namespace YH.Framework.Web.Areas.CmsAdmin.Validator.Configuration
{
    public class SettingValidator : AbstractValidator<SettingModel>
    {
        public SettingValidator()
        {
            RuleFor(setting => setting.Name).NotNull().Length(5, 10);
            RuleFor(setting => setting.Value).NotNull().Length(0, 10);
        }
    }
}
