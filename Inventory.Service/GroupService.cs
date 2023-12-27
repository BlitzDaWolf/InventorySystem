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
            groupData.Add(new Data.Entities.Group { 
                GroupPermisions = permissions,
                Users = {userService.GetUser(userId)},
            });
        }

        public Group GetGroup(Guid groupId)
        {
            var g = groupData.GetById(groupId);
            if (g == null) throw new Exception($"Group with id {groupId} does not exsist");

            // g.Owner = userService.GetUser(g.OwnerId);

            return g;
        }

        public List<Group> GetUserGroup(Guid userId)
        {
            return groupData.Where(x => x.Users.FirstOrDefault(y => y.Id == userId) != null).ToList();
        }

        public void JoinGroup(Guid id, Guid guid)
        {
            var g = groupData.GetById(id);
            g.Users.Add(userService.GetUser(guid));
            groupData.Update(g);
        }
    }
}
