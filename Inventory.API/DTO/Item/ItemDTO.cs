using Inventory.API.DTO.Location;
using Inventory.Data.Enums;

namespace Inventory.API.DTO.Item
{
    public class ItemDTO
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public LocationDTO Location { get; set; }
        public Status ItemStatus { get; set; }
    }
}
