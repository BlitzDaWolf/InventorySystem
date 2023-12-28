using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL.Pagnation
{
    public class PagnationRequest
    {
        public int Size { get; set; } = 8;
        public int Page { get; set; } = 0;

        public int ToSkip => Page * Size;
    }
}
