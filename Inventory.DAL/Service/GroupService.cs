using Inventory.DAL.Context;
using Inventory.DAL.Service.Interface;
using Inventory.Data.Entities;
using Inventory.Data.Service;

namespace Inventory.DAL.Service
{
    public class GroupService : BaseService<Group>, IGroupService
    {
        public GroupService(InventoryContext context) : base(context)
        {
        }
    }
}
