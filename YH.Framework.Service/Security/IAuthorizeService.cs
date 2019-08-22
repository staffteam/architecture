using YH.Framework.Core.Domain.Users;

namespace YH.Framework.Service.Security
{
    public interface IAuthorizeService
    {
        void SignIn(User user, bool rememberMe);

        void SignOut();

        User GetAuthorizedUser();
    }
}
