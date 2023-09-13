namespace Inventory.Data.Entities
{
    public class Location : BaseEntity
    {
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public DateTime LastChecked { get; set; } = DateTime.Now;
    }
}
