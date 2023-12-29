using AutoMapper;
using Inventory.API.DTO.Item;
using Inventory.API.DTO.PagnationDTO;
using Inventory.DAL.Pagnation;
using Inventory.Data.Entities;
using Inventory.Service;
using Inventory.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        readonly IItemService itemService;
        readonly IMapper mapper;

        public ItemController(IItemService itemService, IMapper mapper)
        {
            this.itemService = itemService;
            this.mapper = mapper;
        }

        [HttpGet("{locationId:guid}")]
        public ActionResult<PagnationResponseDTO<ItemDTO>> Index(Guid locationId, int page=0, int size=8)
        {
            PagnationResponse<Item> response = itemService.GetItems(locationId, new PagnationRequest { Page = page, Size = size});
            return Ok(mapper.Map<PagnationResponseDTO<ItemDTO>>(response));
        }

        [HttpPost("{locationId:guid}")]
        public IActionResult CreateItem(Guid locationId, CreateItemDTO item)
        {
            itemService.CreateItem(locationId, item.ItemName, item.ItemDescription);
            return Created();
        }

        [HttpGet("{locationId:guid}/{itemId:guid}")]
        public ActionResult ItemIndex(Guid locationId, Guid itemId)
        {
            Item foundItem = itemService.GetItem(itemId);
            if(foundItem.LocationId != locationId)
            {
                return BadRequest("This item is not in this location");
            }
            return Ok(mapper.Map<ItemDetailDTO>(foundItem));
        }

        [HttpPost("{locationId:guid}/{itemId:guid}/checkout")]
        public IActionResult CheckOut(Guid locationId, Guid itemId)
        {
            var uid = User.Claims.FirstOrDefault(x => x.Type == "userid")!.Value;
            var userId = Guid.Parse(uid);

            Item foundItem = itemService.GetItem(itemId);
            if (foundItem.Checkouts.Any(x => x.CheckInTime == null)) return BadRequest("Item is alread CheckedOut");

            itemService.Checkout(itemId, userId);

            return Ok();
        }

        [HttpPost("{locationId:guid}/{itemId:guid}/checkin")]
        public IActionResult CheckIn(Guid locationId, Guid itemId)
        {
            var uid = User.Claims.FirstOrDefault(x => x.Type == "userid")!.Value;
            var userId = Guid.Parse(uid);

            Item foundItem = itemService.GetItem(itemId);
            if (foundItem.Checkouts.All(x => x.CheckInTime != null)) return BadRequest("Item is alread CheckedIn");

            itemService.Checkin(itemId);

            return Ok();
        }
    }
}
