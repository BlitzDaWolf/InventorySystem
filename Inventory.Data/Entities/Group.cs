using Inventory.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data.Entities
{
    public class Group : BaseEntity
    {
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }

        public Permision GroupPermisions { get; set; }

        // Many to many UserList
    }
}
