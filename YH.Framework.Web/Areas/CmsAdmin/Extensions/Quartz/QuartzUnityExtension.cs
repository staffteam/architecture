﻿using Unity.Lifetime;
using Quartz;
using System.Collections.Specialized;
using Unity.Extension;
using Unity.Injection;
using Unity;

namespace YH.Framework.Web.Areas.CmsAdmin.Quartz
{
    public class QuartzUnityExtension : UnityContainerExtension
    {
        private readonly NameValueCollection quartzProperties;

        public QuartzUnityExtension(NameValueCollection quartzProperties)
        {
            this.quartzProperties = quartzProperties;
        }

        protected override void Initialize()
        {
            var constructor = new InjectionConstructor(new UnityJobFactory(Container), new InjectionParameter<NameValueCollection>(quartzProperties));

            this.Container.RegisterType<ISchedulerFactory, UnitySchedulerFactory>(new ContainerControlledLifetimeManager(), constructor);

            this.Container.RegisterFactory<IScheduler>(c => c.Resolve<ISchedulerFactory>().GetScheduler().Result);
        }
    }
}
