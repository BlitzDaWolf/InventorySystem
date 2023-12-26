using Inventory.Data.Entities;
using Inventory.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL.Service.Interface
{
    public interface ILocationDataService : IBaseService<Location>
    {
        public IEnumerable<Location> GetLocationsFromGroup(Guid groupId);
    }
}
