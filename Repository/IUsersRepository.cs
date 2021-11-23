using RESTApi.Data.VO;
using RESTApi.Model;

namespace RESTApi.Repository.Generic
{
    public interface IUsersRepository
    {
        Users validateCredentials(UsersVO user);
        Users RefreshUserInfo(Users users);
    }
}