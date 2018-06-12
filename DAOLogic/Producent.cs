using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace DAOLogic
{
    public class Producent : IProducent
    {
        public String Name { get; set; } = "Golem";
        public String Town { get; set; } = "Poznań";
        public String Street { get; set; } = "Plac Wolności";
        public int StreetNumber { get; set; } = 10;

        public Producent(String _name, String _town, String _street, int _streetNumber)
        {
            Name = _name;
            Town = _town;
            Street = _street;
            StreetNumber = _streetNumber;
        }

        public Producent()
        {

        }
    }
}
