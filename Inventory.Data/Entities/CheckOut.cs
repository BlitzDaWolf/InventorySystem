using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data.Entities
{
    public class CheckOut : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public string CheckoutReason { get; set; } = "";
        public string Checkin { get; set; } = "";

        public DateTime CheckoutTime { get; set; } = DateTime.Now;
        public DateTime CheckinTime { get; set; } = DateTime.Now;
    }
}
