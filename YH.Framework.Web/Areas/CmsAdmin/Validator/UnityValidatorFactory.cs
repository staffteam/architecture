using FluentValidation;
using Microsoft.Practices.Unity;
using System;
using System.Linq;
using Unity;
using Unity.Resolution;
using YH.Framework.Core.Infrastructure;

namespace YH.Framework.Web.Areas.CmsAdmin.Validator
{
    public class UnityValidatorFactory : ValidatorFactoryBase
    {
        private readonly IUnityContainer container;

        public UnityValidatorFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            return container.TryResolve<IValidator>(validatorType.GetGenericArguments().First().FullName);
        }
    }
}
