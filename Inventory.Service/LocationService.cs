using Inventory.DAL.Service.Interface;
using Inventory.Data.Entities;
using Inventory.Service.Interfaces;

namespace Inventory.Service
{
    public class LocationService : ILocationService
    {
        ILocationDataService locationData;

        public LocationService(ILocationDataService locationData)
        {
            this.locationData = locationData;
        }

        public void CreateLocation(string name, Guid group)
        {
            locationData.Add(new Location {  GroupId = group, LocationName = name });
        }

        public List<Location> GetLocations(Guid GroupId)
        {
            return locationData.Where(x => x.GroupId == GroupId).ToList();
        }
    }
}
