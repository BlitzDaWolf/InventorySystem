namespace Inventory.API.DTO.Group
{
    public class GroupDTO
    {
        public Guid Id { get; set; }
        public List<UserGroupDTO> Users { get; set; }
    }

    public class UserGroupDTO
    {
        public string UserName { get; set; }
    }
}
