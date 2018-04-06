using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace DAOLogic
{
    public class DataObject
    {
        public Race race { get; set; }
        public Speciality speciality { get; set; }
        public Double alcoholPercent { get; set; }
        public int IBU { get; set; }
        public int EBC { get; set; }
        public int servingTemperature { get; set; }
        public Double BLG { get; set; }
        public DateTime bestBefore { get; set; }
        public String seaStory { get; set; }
        public String ingredients { get; set; }

        public DataObject(Race _race, Speciality _speciality, Double _alcoholPercent, int _IBU, int _EBC, int _servingTemperature,
                                                            Double _BLG, DateTime _bestBefore, String _seaStory, String _ingredients )
        {
            race = _race;
            speciality = _speciality;
            alcoholPercent = _alcoholPercent;
            IBU = _IBU;
            EBC = _EBC;
            servingTemperature = _servingTemperature;
            BLG = _BLG;
            bestBefore = _bestBefore;
            seaStory = _seaStory;
            ingredients = _ingredients;
        }
    }
}
