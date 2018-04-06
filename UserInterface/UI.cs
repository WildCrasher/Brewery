using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace UserInterface
{
    public class UI
    {
        static void Main(string[] args)
        {
            BL _bl = new BL();
            _bl.dao.print();
        }
    }
}
