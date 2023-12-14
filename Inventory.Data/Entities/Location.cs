using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data.Entities
{
    public class Location : BaseEntity
    {
        public string LocationName { get; set; }

        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
