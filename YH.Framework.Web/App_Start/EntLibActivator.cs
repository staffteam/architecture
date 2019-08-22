using FluentValidation.Mvc;
using System.Web.Mvc;
using YH.Framework.Web.Areas.CmsAdmin.Validator;
using System.Linq;
using YH.Framework.Web.Areas.CmsAdmin.Infrastructure;
using System.IO;
using System;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(YH.Framework.Web.App_Start.EntLibActivator), "Start")]
namespace YH.Framework.Web.App_Start
{
    public static class EntLibActivator
    {
        public static void Start()
        {
            string configurationFilepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EntLib.config");
            IConfigurationSource configurationSource = new FileConfigurationSource(configurationFilepath);

            LogWriterFactory logWriterFactory = new LogWriterFactory(configurationSource);
            Logger.SetLogWriter(logWriterFactory.Create());

            ExceptionPolicyFactory exceptionPolicyFactory = new ExceptionPolicyFactory(configurationSource);
            ExceptionPolicy.SetExceptionManager(exceptionPolicyFactory.CreateManager());
        }
    }
}
