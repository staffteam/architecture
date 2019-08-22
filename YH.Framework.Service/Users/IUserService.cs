using YH.Framework.Core.Domain.Users;
using YH.Framework.Core.Paging;

namespace YH.Framework.Service.Users
{
    public interface IUserService
    {
        void CreateUser(User user);

        void UpdateUser(User user);

        User GetUser(string userName);

        User GetUser(int id);

        void DeleteUser(User user);

        void DeleteUser(int id);

        bool ValidateUser(string userName, string password);

        User GetUserByWeChatOpenID(string weChatOpenId);

        IPagedList<User> GetUsers(string keyword, int pageNumber, int pageSize);
    }
}
