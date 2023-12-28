using Inventory.DAL.Pagnation;
using Inventory.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Service.Interfaces
{
    public interface IItemService
    {
        void CreateItem(Guid locationId, string itemName, string itemDescription);
        PagnationResponse<Item> GetItems(Guid locationId, PagnationRequest pagnationRequest);
    }
}
