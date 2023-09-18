using Inventory.Data.Context;
using Inventory.Data.Entities;
using Inventory.Data.Service;

namespace Inventory.DAL.Service
{
    public class CheckOutService : BaseService<CheckOut>
    {

        public CheckOutService(InventoryContext context) : base(context) { }

        public IEnumerable<CheckOut> GetCheckoutsFromItem(int itemId) => Where(x => x.ItemId== itemId);
    }
}
