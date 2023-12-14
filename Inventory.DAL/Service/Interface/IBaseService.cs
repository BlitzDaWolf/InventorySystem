using Inventory.DAL.Context;
using Inventory.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.DAL.Service.Interface
{
    public interface IBaseService<T> where T : BaseEntity
    {

        public void Add(T item);
        public void Delete(T item);
        public void Update(T item);

        public ICollection<T> GetAll();
        public T GetById(Guid id);

        public IEnumerable<T> Where(Func<T, bool> predicate);
        public T? Find(Func<T, bool> predicate);
        public bool Exsist(Func<T, bool> predicate);

        public void AddAsync(T Item);
    }
}
