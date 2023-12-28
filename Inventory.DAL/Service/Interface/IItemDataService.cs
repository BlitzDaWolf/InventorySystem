using Inventory.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL.Service.Interface
{
    public interface IItemDataService : IPagnationService<Item>
    {
    }
}
