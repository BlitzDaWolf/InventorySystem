using Inventory.Data.Enums;

namespace Inventory.Data.Entities
{
    public class Group : BaseEntity
    {
        //public Guid OwnerId { get; set; }
        //public User Owner { get; set; }
        public Permision GroupPermisions { get; set; }

        public virtual List<User> Users { get; set; } = new();
    }
}
