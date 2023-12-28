using Inventory.DAL.Pagnation;
using Inventory.DAL.Service.Interface;
using Inventory.Data.Entities;
using Inventory.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Service
{
    public class ItemService : IItemService
    {
        readonly IItemDataService itemData;

        public ItemService(IItemDataService itemData)
        {
            this.itemData = itemData;
        }

        public void CreateItem(Guid locationId, string itemName, string itemDescription)
        {
            itemData.Add(new Item { ItemDescription = itemDescription, ItemName = itemName, LocationId = locationId });
        }

        public PagnationResponse<Item> GetItems(Guid locationId, PagnationRequest pagnationRequest)
        {
            return itemData.GetPagnation(pagnationRequest, null);
        }
    }
}
