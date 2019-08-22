using YH.Framework.Core.Domain.Users;

namespace YH.Framework.Core.Infrastructure
{
    public interface IWorkContext
    {
        User CurrentUser { get; }
    }
}
