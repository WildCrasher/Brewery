using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Interfaces
{
    public interface IBeer
    {
        Race Race { get; set; }
        Speciality Speciality { get; set; }
        IProducent Producent { get; set; }
        Double AlcoholPercent { get; set; }
        int IBU { get; set; }
        int EBC { get; set; }
        int ServingTemperature { get; set; }
        Double BLG { get; set; }
        DateTime BestBefore { get; set; }
        String SeaStory { get; set; }
        String Ingredients { get; set; }
    }
}
