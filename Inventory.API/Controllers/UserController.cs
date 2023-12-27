using Microsoft.AspNetCore.Mvc;
using Inventory.Service.Interfaces;
using Inventory.API.DTO.User;

namespace Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("login")]
        public string Login(LoginDTO login)
        {
            return userService.Login(login.UserName, login.Password);
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDTO register)
        {
            userService.Register(register.UserName,
                register.Password,
                register.RePassword,
                register.Email);
            return Created("login", "");
        }
    }
}
