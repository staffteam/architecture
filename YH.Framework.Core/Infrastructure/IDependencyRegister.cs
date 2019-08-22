using Unity.Lifetime;
using Unity;

namespace YH.Framework.Core.Infrastructure
{
    public interface IDependencyRegister
    {
        void RegisterTypes(IUnityContainer container);
    }
}
