using Inventory.DAL.Pagnation;

namespace Inventory.API.DTO.PagnationDTO
{
    public class PagnationResponseDTO<T>
    {
        public IEnumerable<T> Data { get; set; }
        public PagnationRequest Request { get; set; }
        public int TotalSize { get; set; }
    }
}
