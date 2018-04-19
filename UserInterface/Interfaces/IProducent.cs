using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IProducent
    {
        String name { get; set; }
        String town { get; set; }
        String street { get; set; }
        int streetNumber { get; set; }
    }
}
