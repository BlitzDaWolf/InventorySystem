using AutoMapper;
using Inventory.API.DTO.Item;
using Inventory.API.DTO.PagnationDTO;
using Inventory.DAL.Pagnation;
using Inventory.Data.Entities;
using Inventory.Service;
using Inventory.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
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
        public ActionResult CreateItem(Guid locationId, CreateItemDTO item)
        {
            itemService.CreateItem(locationId, item.ItemName, item.ItemDescription);
            return Created();
        }

        [HttpGet("{locationId:guid}/{itemId:guid}")]
        public IActionResult ItemIndex(Guid locationId, Guid itemId)
        {
            return Ok();
        }

        [HttpPost("{locationId:guid}/{itemId:guid}/checkout")]
        public IActionResult CheckOut(Guid locationId, Guid itemId)
        {
            return Ok();
        }

        [HttpPost("{locationId:guid}/{itemId:guid}/checkin")]
        public IActionResult CheckIn(Guid locationId, Guid itemId)
        {
            return Ok();
        }
    }
}
