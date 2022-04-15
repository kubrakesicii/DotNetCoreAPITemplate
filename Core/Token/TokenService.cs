using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Token
{
    public class TokenService : ITokenService
    {
        private readonly JwtOption _jwtOptions;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenService(JwtOption jwtOptions, IHttpContextAccessor httpContextAccessor)
        {
            _jwtOptions = jwtOptions;
            _httpContextAccessor = httpContextAccessor;
        }

        public string CreateToken(int id, string email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecurityKey));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var jwt = CreateJwtSecurityToken(id, email, signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return token;
        }

        public async Task<List<Claim>> GetUserClaims()
        {
            return await Task.Run(() =>
               new List<Claim>
               {
                     _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier),
                     _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name)
               }
           );
        }

        private JwtSecurityToken CreateJwtSecurityToken(int id, string email,SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                _jwtOptions.Issuer,
                _jwtOptions.Audience,
                expires: DateTime.Now.AddMinutes(_jwtOptions.AccessTokenExpiration),
                notBefore: DateTime.Now,
                claims: new List<Claim>
                {
                    new Claim("id", id.ToString()),
                    new Claim("email", email)
                },
                signingCredentials: signingCredentials
            );
            return jwt;
        }
    }
}
