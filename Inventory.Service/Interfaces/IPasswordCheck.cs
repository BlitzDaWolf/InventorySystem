using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Service.Interfaces
{
    public interface IPasswordCheck
    {
        public bool ValidPassword(string password) => true;
        public string HasPassword(string password);
        public bool CheckPassword(string source, string value);
    }
}
