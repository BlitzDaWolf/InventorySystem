using AutoMapper;
using Inventory.API.DTO.Checkout;
using Inventory.API.DTO.Group;
using Inventory.API.DTO.Item;
using Inventory.API.DTO.Location;
using Inventory.API.DTO.PagnationDTO;
using Inventory.DAL.Pagnation;
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

            CreateMap<Item, ItemDTO>().ReverseMap();
            CreateMap<PagnationResponse<Item>, PagnationResponseDTO<ItemDTO>>().ReverseMap();

            CreateMap<Checkout, CheckOutDTO>().ReverseMap();
            CreateMap<Item, ItemDetailDTO>().ReverseMap();
        }
    }
}
