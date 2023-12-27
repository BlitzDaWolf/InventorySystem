using Inventory.Service.Interfaces;

namespace Inventory.API.ServiceHelpers
{
    public class PasswordCheck : IPasswordCheck
    {
        public bool CheckPassword(string source, string value)
        {
            return true;
        }

        public string HasPassword(string password)
        {
            return password;
        }
    }
}
