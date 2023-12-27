using Inventory.Data.Entities;
using Inventory.Data.Enums;

namespace Inventory.Service.Interfaces
{
    public interface IGroupService
    {
        public void CreateGroup(Permision permissions, Guid userId);
        public Group GetGroup(Guid groupId);
        public List<Group> GetUserGroup(Guid guid);
    }
}
