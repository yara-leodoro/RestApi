using RESTApi.Data.VO;
using RESTApi.Model;

namespace RESTApi.Bunisses
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UsersVO user);    
        TokenVO ValidateCredentials(TokenVO token); 
        bool RevokeToken(string userName);   
        
    }
}