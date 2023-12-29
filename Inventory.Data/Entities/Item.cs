using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Data.Enums;

namespace Inventory.Data.Entities
{
    public class Item : BaseEntity
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }

        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }

        public Status ItemStatus { get; set; }

        public virtual List<Checkout> Checkouts { get; set; }
    }
}
