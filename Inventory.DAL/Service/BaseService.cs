using Inventory.Data.Context;
using Inventory.Data.Entities;

namespace Inventory.Data.Service
{
    public abstract class BaseService<T> where T : BaseEntity
    {
        protected readonly InventoryContext _context;

        protected BaseService(InventoryContext context)
        {
            _context = context;
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }
        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }
        public void Update(T item)
        {
            _context.Set<T>().Update(item);
            _context.SaveChanges();
        }
        
        public ICollection<T> GetAll() => _context.Set<T>().ToArray();
        public T GetById(int id) => Find(x => x.Id == id);
        public ICollection<T> GetByRange(int start, int end) => Where(x => x.Id > start && x.Id <= end).ToArray();

        public IEnumerable<T> Where(Func<T, bool> predicate) => _context.Set<T>().Where(predicate);
        public T? Find(Func<T, bool> predicate) => _context.Set<T>().FirstOrDefault(predicate);
        public bool Exsist(Func<T, bool> predicate) => Find(predicate) != null;

        public async void AddAsync(T Item)
        {
            await _context.Set<T>().AddAsync(Item);
            await _context.SaveChangesAsync();
        }
    }
}
