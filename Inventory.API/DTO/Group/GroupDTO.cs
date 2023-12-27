namespace Inventory.API.DTO.Group
{
    public class GroupDTO
    {
        public Guid Id { get; set; }
        public UserGroupDTO Owner { get; set; }
    }

    public class UserGroupDTO
    {
        public string UserName { get; set; }
    }
}
