using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inventory.DAL.Service.Interface;
using Inventory.Data.Entities;

namespace Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        readonly ILocationDataService locationService;

        public LocationController(ILocationDataService locationService)
        {
            this.locationService = locationService;
        }

        // CRUD
        [HttpPost]
        public IActionResult CreateItem()
        {
            locationService.Add(new Location { GroupId = Guid.Empty, LocationName = "tmp" });
            return Accepted();
        }

        // TODO: Show only from group
        [HttpGet] public ICollection<Location> GetLocations() => locationService.GetAll();
        [HttpGet("{id}")] public Location GetLocation(Guid id) => locationService.GetById(id);

        [HttpPut]
        public IActionResult Update(Location location)
        {
            locationService.Update(location);
            return Accepted();
        }
    }
}
