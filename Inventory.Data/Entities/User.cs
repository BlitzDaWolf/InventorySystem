namespace Inventory.Data.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime Created { get; set; } = DateTime.Now;

        public virtual List<Group> OwnedGroups { get; set; }
    }
}
