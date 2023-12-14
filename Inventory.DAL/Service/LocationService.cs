using Inventory.DAL.Context;
using Inventory.DAL.Service.Interface;
using Inventory.Data.Entities;
using Inventory.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL.Service
{
    public class LocationService : BaseService<Location>, ILocationService
    {
        public LocationService(InventoryContext context) : base(context)
        {
        }
    }
}
