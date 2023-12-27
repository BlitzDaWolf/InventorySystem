using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inventory.DAL.Service.Interface;
using Inventory.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Inventory.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        readonly IGroupDataService groupService;

        public GroupController(IGroupDataService groupService)
        {
            this.groupService = groupService;
        }

        [HttpPost]
        public IActionResult CreateItem()
        {
            // IGroupService.Add(new Group { GroupId = Guid.Empty, LocationName = "tmp" });
            return Accepted();
        }

        [HttpGet] public ICollection<Group> GetGroups() => groupService.GetAll();
        [HttpGet("{id}")] public Group GetGroup(Guid id) => groupService.GetById(id);

        [HttpPut]
        public IActionResult Update(Group group)
        {
            groupService.Update(group);
            return Accepted();
        }
    }
}
