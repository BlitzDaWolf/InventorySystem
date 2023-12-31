﻿using Inventory.DAL.Context;
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
    public class LocationDataService : BaseDataService<Location>, ILocationDataService
    {
        public LocationDataService(InventoryContext context) : base(context)
        {
        }

        public IEnumerable<Location> GetLocationsFromGroup(Guid groupId) => Where(x => x.GroupId == groupId);
    }
}
