using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IProducent
    {
        String Name { get; set; }
        String Town { get; set; }
        String Street { get; set; }
        int StreetNumber { get; set; }
    }
}
