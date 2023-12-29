using Inventory.Data.Entities;

namespace Inventory.DAL.Pagnation
{
    public class PagnationResponse<T> where T : BaseEntity
    {
        public IEnumerable<T> Data { get; set; }
        public PagnationRequest Request { get; set; }
        public int TotalSize { get; set; }
    }
}
