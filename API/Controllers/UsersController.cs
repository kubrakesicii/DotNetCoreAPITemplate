using Business.Abstract;
using Entities.DTO.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public ActionResult Login([FromBody] LoginDto loginDto)
        {
            return Ok(_userService.Login(loginDto));
        }
    }
}
