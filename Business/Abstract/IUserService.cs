using Core.Results;
using Entities.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        DataResult<GetUserDto> Login(LoginDto loginDto);
    }
}
