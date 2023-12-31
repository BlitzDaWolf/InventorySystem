﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult CreateGroup(CreateGroupDTO groupDto)
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

        [HttpGet("my")]
        public List<GroupDTO> MyGroup()
        {
            var uid = User.Claims.FirstOrDefault(x => x.Type == "userid")!.Value;
            var guid = Guid.Parse(uid);
            return mapper.Map<List<GroupDTO>>(groupService.GetUserGroup(guid));
        }

        [HttpPost("join/{id:guid}")]
        public void JoinGroup(Guid id)
        {
            var uid = User.Claims.FirstOrDefault(x => x.Type == "userid")!.Value;
            var guid = Guid.Parse(uid);
            groupService.JoinGroup(id, guid);
        }
    }
}
