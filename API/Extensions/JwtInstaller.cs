using Core.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Extension
{
    public static class JwtInstaller
    {
        public static IServiceCollection InstallJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = new JwtOption
            {
                Issuer = "softserversupport.com",
                Audience = "softserversupport.com",
                SecurityKey = configuration["JWT_SECURITY_KEY"],
                AccessTokenExpiration = 60 * 60 * 24 * 7
            };
            services.AddSingleton(jwtOptions);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecurityKey)),
                    ClockSkew = TimeSpan.Zero
                };
            });
            return services;
        }
    }
}
