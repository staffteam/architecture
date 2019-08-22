﻿using FluentValidation.Mvc;
using System.Web.Mvc;
using YH.Framework.Web.Areas.CmsAdmin.Validator;
using System.Linq;
using YH.Framework.Web.Areas.CmsAdmin.Infrastructure;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(YH.Framework.Web.App_Start.ExtensionsActivator), "Start")]
namespace YH.Framework.Web.App_Start
{
    public static class ExtensionsActivator
    {
        public static void Start()
        {
            FluentValidationModelValidatorProvider.Configure(cfg => cfg.ValidatorFactory = new UnityValidatorFactory(UnityConfig.GetConfiguredContainer()));

            ModelMetadataProviders.Current = new CustomModelMetadataProvider();

            var clientDataTypeValidator = ModelValidatorProviders.Providers.OfType<ClientDataTypeModelValidatorProvider>().FirstOrDefault();
            if (clientDataTypeValidator != null)
            {
                ModelValidatorProviders.Providers.Remove(clientDataTypeValidator);
            }
            ModelValidatorProviders.Providers.Add(new CustomClientDataTypeModelValidatorProvider());
        }
    }
}
