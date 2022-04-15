using DataAccess.GenericRepository;
using Entities.Concrete;
using Entities.DTO.User;

namespace DataAccess.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        GetUserDto Login(LoginDto loginDto);
    }
}
