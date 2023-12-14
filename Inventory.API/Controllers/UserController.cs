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
        readonly IUserServicve userServicve;

        public UserController(IUserServicve userServicve)
        {
            this.userServicve = userServicve;
        }

        [HttpGet]
        public ICollection<User> Index()
        {
            return userServicve.GetAll();
        }
    }
}
