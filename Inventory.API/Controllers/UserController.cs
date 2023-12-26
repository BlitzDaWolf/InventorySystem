using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inventory.DAL.Service;
using Inventory.DAL.Service.Interface;
using Inventory.Data.Entities;

namespace Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserDataServicve userServicve;

        public UserController(IUserDataServicve userServicve)
        {
            this.userServicve = userServicve;
        }

        [HttpGet]
        public ICollection<User> Index()
        {
            return userServicve.GetAll();
        }

        [HttpPost("login")]
        public string Login()
        {
            return "";
        }

        [HttpPost("register")]
        public IActionResult Register()
        {
            return Created("login", "");
        }
    }
}
