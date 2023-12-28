using AutoMapper;
using Inventory.API.DTO.Group;
using Inventory.API.DTO.Location;
using Inventory.Data.Entities;

namespace Inventory.API.Mapper
{
    public class InventoryMapper : Profile
    {
        public InventoryMapper()
        {
            CreateMap<User, UserGroupDTO>().ReverseMap();
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Location, LocationDTO>().ReverseMap();
        }
    }
}
