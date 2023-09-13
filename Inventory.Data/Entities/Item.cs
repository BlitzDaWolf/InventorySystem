namespace Inventory.Data.Entities
{
    public enum CheckoutState
    {
        AtLocation,
        InUse,
        Lost
    }

    public enum ItemStatus
    {
        Unknown,
        Broken,
        Fixed
    }

    public class Item : BaseEntity
    {
        public string Description { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.Now;

        public CheckoutState Checkedout { get; set; }
        public ItemStatus Status { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int? LastUserId { get; set; }
        public User LastUser { get; set; }

        public ICollection<CheckOut> Checkouts { get; set; } = new List<CheckOut>();
    }
}
