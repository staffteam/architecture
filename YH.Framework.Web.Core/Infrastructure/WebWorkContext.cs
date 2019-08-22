using Unity.Lifetime;
using Unity;
using YH.Framework.Core.Domain.Users;
using YH.Framework.Core.Infrastructure;
using YH.Framework.Service.Security;

namespace YH.Framework.Web.Core.Infrastructure
{
    public class WebWorkContext : IWorkContext
    {
        private readonly IUnityContainer container = null;

        public WebWorkContext(IUnityContainer unityContainer)
        {
            this.container = unityContainer;
        }

        public IUnityContainer Container
        {
            get { return this.container; }
        }

        public User CurrentUser
        {
            get { return container.Resolve<IAuthorizeService>().GetAuthorizedUser(); }
        }
    }
}
