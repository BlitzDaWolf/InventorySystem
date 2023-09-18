using Inventory.Data.Context;
using Inventory.Data.Entities;
using Inventory.Data.Service;

namespace Inventory.DAL.Service
{
    public class ItemService : BaseService<Item>
    {
        public ItemService(InventoryContext context) : base(context) { }

        public IEnumerable<Item> GetByLocation(int location) => Where(x => x.LocationId == location);
        public IEnumerable<Item> GetCheckedIn() => Where(x => x.Checkedout == CheckoutState.AtLocation);
        public IEnumerable<Item> GetFromState(CheckoutState state) => Where(x => x.Checkedout == state);

        public IEnumerable<Item> GetBrokenItems() => Where(x => x.Status == ItemStatus.Broken);
    }
}
