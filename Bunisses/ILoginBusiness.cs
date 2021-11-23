using RESTApi.Data.VO;
using RESTApi.Model;

namespace RESTApi.Bunisses
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UsersVO user);        
        
    }
}