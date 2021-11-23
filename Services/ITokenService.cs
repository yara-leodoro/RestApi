using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;

namespace RESTApi.Services
{
    public interface ITokenService
    {
        string GeneteAcessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        
    }
}