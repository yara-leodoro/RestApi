using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using RESTApi.Configurations;
using RESTApi.Data.VO;
using RESTApi.Repository.Generic;
using RESTApi.Services;

namespace RESTApi.Bunisses.Implementations
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT ="yyyy-MM-dd HH:mm:ss";
        private TokenConfigurations _configurations;
        private IUsersRepository _repository;
        private readonly ITokenService _tokenService;

        public LoginBusinessImplementation(TokenConfigurations configurations, IUsersRepository repository, ITokenService tokenService)
        {
            _configurations = configurations;
            _repository = repository;
            _tokenService = tokenService;
        }

        public TokenVO ValidateCredentials(UsersVO userCredentials)
        {
            var user = _repository.validateCredentials(userCredentials);

            if (user == null) return null;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var accessToken = _tokenService.GeneteAcessToken(claims);

            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.ResfreshTokenExpiryTime = DateTime.Now.AddDays(_configurations.DaysToExpiry);

            _repository.RefreshUserInfo(user);
            
            DateTime createDate = DateTime.Now;
            DateTime experationDate = createDate.AddMinutes(_configurations.Minutes);


            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                experationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
            );
        }
    }
}