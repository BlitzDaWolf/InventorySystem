using Inventory.Data.Context;
using Inventory.Data.Entities;
using Inventory.Data.Service;

namespace Inventory.DAL.Service
{
    public class UserService : BaseService<User>
    {
        public UserService(InventoryContext context) : base(context) { }

        public bool UserExsist(string username) => Exsist(x => x.Name == username);
        public User GetUser(string username) => Find(x => x.Name == username);
    }
}
