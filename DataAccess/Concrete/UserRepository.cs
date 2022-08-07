using Core.Errors;
using DataAccess.Abstract;
using DataAccess.Context;
using DataAccess.GenericRepository;
using DataAccess.Helper;
using Entities.Concrete;
using Entities.DTO.User;

namespace DataAccess.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(TempContext context) : base(context)
        {
        }

        public GetUserDto Login(LoginDto loginDto)
        {
            var user = _context.Users.Where(x => x.Email == loginDto.Email).FirstOrDefault();
            if (user == null)
                throw new BadRequestError();

            var verify = PasswordHelper.VerifyPassword(loginDto.Password, user.Password);
            if (!verify)
                throw new NotFoundError();

            return new GetUserDto
            {
                Id = user.Id,
                Email = user.Email
            };
        }
    }
}
