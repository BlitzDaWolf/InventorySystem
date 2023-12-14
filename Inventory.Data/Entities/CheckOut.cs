using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data.Entities
{
    public class Checkout : BaseEntity
    {
        public Guid ItemId{ get; set; }
        public Item Item { get; set; }

        public Guid CheckOutUserId { get; set; }
        public User CheckOutUser { get; set; }

        public DateTime CheckoutTime { get; set; } = DateTime.Now;
        public DateTime? CheckInTime { get; set; } = null;
    }
}
