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
        readonly ICheckoutDataService checkoutData;

        public ItemService(IItemDataService itemData, ICheckoutDataService checkoutData)
        {
            this.itemData = itemData;
            this.checkoutData = checkoutData;
        }

        public void Checkin(Guid itemId)
        {
            var co = checkoutData.Find(x => x.ItemId == itemId && x.CheckInTime == null) ?? throw new Exception("No checkout found with these options");
            co.CheckInTime = DateTime.Now;
            checkoutData.Update(co);
        }

        public void Checkout(Guid itemId, Guid userId)
        {
            checkoutData.Add(new Checkout
            {
                ItemId = itemId, CheckOutUserId = userId
            });
        }

        public void CreateItem(Guid locationId, string itemName, string itemDescription)
        {
            itemData.Add(new Item { ItemDescription = itemDescription, ItemName = itemName, LocationId = locationId });
        }

        public Item GetItem(Guid itemId)
        {
            return itemData.GetById(itemId) ?? throw new Exception("Item not found");
        }

        public PagnationResponse<Item> GetItems(Guid locationId, PagnationRequest pagnationRequest)
        {
            return itemData.GetPagnation(pagnationRequest, null);
        }
    }
}
