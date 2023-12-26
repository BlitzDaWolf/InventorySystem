using Inventory.DAL.Context;
using Inventory.DAL.Service.Interface;
using Inventory.Data.Entities;
using Inventory.Data.Service;

namespace Inventory.DAL.Service
{
    public class GroupDataService : BaseDataService<Group>, IGroupDataService
    {
        public GroupDataService(InventoryContext context) : base(context)
        {
        }
    }
}
