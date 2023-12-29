using Inventory.API.DTO.Group;

namespace Inventory.API.DTO.Checkout
{
    public class CheckOutDTO
    {
        public virtual UserGroupDTO CheckOutUser { get; set; }

        public DateTime CheckoutTime { get; set; } = DateTime.Now;
        public DateTime? CheckInTime { get; set; } = null;

        public TimeSpan? ItemUsed => CheckInTime! - CheckoutTime;
    }
}
