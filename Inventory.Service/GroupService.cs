using Inventory.DAL.Service.Interface;
using Inventory.Data.Entities;
using Inventory.Data.Enums;
using Inventory.Service.Interfaces;

namespace Inventory.Service
{
    public class GroupService : IGroupService
    {
        IGroupDataService groupData;
        IUserService userService;

        public GroupService(IGroupDataService groupData, IUserService userService)
        {
            this.groupData = groupData;
            this.userService = userService;
        }

        public void CreateGroup(Permision permissions, Guid userId)
        {
            groupData.Add(new Data.Entities.Group {  GroupPermisions = permissions, OwnerId = userId });
        }

        public Group GetGroup(Guid groupId)
        {
            var g = groupData.GetById(groupId);
            if (g == null) throw new Exception($"Group with id {groupId} does not exsist");

            g.Owner = userService.GetUser(g.OwnerId);

            return g;
        }
    }
}
