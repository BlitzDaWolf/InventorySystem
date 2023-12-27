using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inventory.DAL.Service.Interface;
using Inventory.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Inventory.Service.Interfaces;
using Inventory.API.DTO.Group;
using AutoMapper;

namespace Inventory.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        readonly IGroupService groupService;
        readonly IMapper mapper;

        public GroupController(IGroupService groupService, IMapper mapper)
        {
            this.groupService = groupService;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateItem(CreateGroupDTO groupDto)
        {
            var uid = User.Claims.FirstOrDefault(x => x.Type == "userid")!.Value;
            var guid = Guid.Parse(uid);
            groupService.CreateGroup(groupDto.Permissions, guid);
            return Accepted();
        }

        [HttpGet("{id:guid}")]
        public GroupDTO GetGroup(Guid id)
        {
            return mapper.Map<GroupDTO>(groupService.GetGroup(id));
        }


        /*[HttpGet] public ICollection<Group> GetGroups() => groupService.GetAll();
        [HttpGet("{id}")] public Group GetGroup(Guid id) => groupService.GetById(id);

        [HttpPut]
        public IActionResult Update(Group group)
        {
            groupService.Update(group);
            return Accepted();
        }*/
    }
}
