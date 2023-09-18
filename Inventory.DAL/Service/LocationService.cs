using Inventory.Data.Context;
using Inventory.Data.Entities;
using Inventory.Data.Service;

namespace Inventory.DAL.Service
{
    public class LocationService : BaseService<Location>
    {
        public LocationService(InventoryContext context) : base(context) { }
    }
}
