using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inventory.Service.Interfaces;
using Inventory.API.DTO.Location;
using AutoMapper;

namespace Inventory.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        readonly ILocationService locationService;
        readonly IMapper mapper;

        public LocationController(ILocationService locationService, IMapper mapper)
        {
            this.locationService = locationService;
            this.mapper = mapper;
        }

        [HttpGet("{id:guid}")]
        public List<LocationDTO> GetLocations(Guid id)
        {
            var locations = locationService.GetLocations(id);
            return mapper.Map<List<LocationDTO>>(locations);
        }

        [HttpPost]
        public IActionResult CreateLocation(CreateLocationDTO location)
        {
            locationService.CreateLocation(location.name, location.group);
            return Created();
        }
    }
}
