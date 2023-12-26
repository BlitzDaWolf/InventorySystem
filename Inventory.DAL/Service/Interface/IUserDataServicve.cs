using Inventory.Data.Entities;

namespace Inventory.DAL.Service.Interface
{
    public interface IUserDataServicve : IBaseService<User>
    {
        public User? GetByName(string name) => Find(x => x.Username.ToLower() == name.ToLower());
        public bool UserExsist(string name) => GetByName(name) != null;
    }
}
