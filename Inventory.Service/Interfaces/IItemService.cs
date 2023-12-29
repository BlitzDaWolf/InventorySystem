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
        void Checkin(Guid itemId);
        void Checkout(Guid itemId, Guid userId);
        void CreateItem(Guid locationId, string itemName, string itemDescription);
        Item GetItem(Guid itemId);
        PagnationResponse<Item> GetItems(Guid locationId, PagnationRequest pagnationRequest);
    }
}
