using Inventory.API.DTO.Checkout;

namespace Inventory.API.DTO.Item
{
    public class ItemDetailDTO : ItemDTO
    {
        public List<CheckOutDTO> Checkouts { get; set; }
    }
}
