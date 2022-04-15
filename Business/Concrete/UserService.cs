using Business.Abstract;
using Core.Results;
using Core.Token;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public UserService(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public DataResult<GetUserDto> Login(LoginDto loginDto)
        {
            var user = _unitOfWork.Users.Login(loginDto);
            user.Token = _tokenService.CreateToken(user.Id, user.Email);
            return new SuccessDataResult<GetUserDto>(user);
        }
    }
}
