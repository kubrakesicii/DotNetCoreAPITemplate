using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Token
{
    public interface ITokenService
    {
        // Bu metodun parametrelerine, token payload içine gömülmek istene tüm datalar verilebilir.
        string CreateToken(int id, string email);
        Task<List<Claim>> GetUserClaims();
    }
}
