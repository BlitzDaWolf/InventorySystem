using Inventory.DAL.Pagnation;
using Inventory.Data.Entities;

namespace Inventory.DAL.Service.Interface
{
    public interface IPagnationService<T> : IBaseService<T> where T : BaseEntity
    {
        public PagnationResponse<T> GetPagnation(PagnationRequest request, Func<T, bool> predicate);
    }
}
