using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DAOLogic;

namespace BusinessLogic
{
    public class BL
    {
        public IDAO dao { get; set; }
        public BL()
        {
            dao = new DAOMock();
        }
    }
}
