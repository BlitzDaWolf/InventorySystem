using Inventory.DAL.Context;
using Inventory.DAL.Pagnation;
using Inventory.DAL.Service.Interface;
using Inventory.Data.Entities;
using Inventory.Data.Service;

namespace Inventory.DAL.Service
{
    public class PagnationService<T> : BaseDataService<T>, IPagnationService<T> where T : BaseEntity
    {
        public PagnationService(InventoryContext context) : base(context)
        {
        }

        public PagnationResponse<T> GetPagnation(PagnationRequest request, Func<T, bool> predicate)
        {
            var baseList = Where(predicate);
            int totalSize = baseList.Count();
            var respose = new PagnationResponse<T> {
                TotalSize = totalSize,
                Request = request,
                Data = baseList.Skip(request.ToSkip).Take(request.Size)
            };
            return respose;
        }
    }
}
