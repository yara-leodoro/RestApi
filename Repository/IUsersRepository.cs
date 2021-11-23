using RESTApi.Data.VO;
using RESTApi.Model;

namespace RESTApi.Repository.Generic
{
    public interface IUsersRepository
    {
        Users validateCredentials(UsersVO user);
        Users validateCredentials(string user);
        bool RevokeToken(string userName);
        Users RefreshUserInfo(Users users);
    }
}