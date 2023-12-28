using Inventory.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Service.Interfaces
{
    public interface ILocationService
    {
        void CreateLocation(string name, Guid group);
        List<Location> GetLocations(Guid GroupId);
    }
}
