using Inventory.DAL.Context;
using Inventory.DAL.Service.Interface;
using Inventory.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL.Service
{
    public class ItemDataService : PagnationService<Item>, IItemDataService
    {
        public ItemDataService(InventoryContext context) : base(context)
        {
        }
    }
}
