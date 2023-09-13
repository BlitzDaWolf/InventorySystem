using Inventory.Data.Context;
using Inventory.Data.Entities;
using Inventory.Data.Service;

namespace Inventory.DAL.Service
{
    public class UserService : BaseService<User>
    {
        public UserService(InventoryContext context) : base(context) { }

        public bool UserExsist(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Name == username) != null;
        }
        public User GetUser(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Name == username);
        }
    }
}
