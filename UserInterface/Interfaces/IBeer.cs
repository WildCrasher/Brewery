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
        Race race { get; set; }
        Speciality speciality { get; set; }
        IProducent producent { get; set; }
        Double alcoholPercent { get; set; }
        int IBU { get; set; }
        int EBC { get; set; }
        int servingTemperature { get; set; }
        Double BLG { get; set; }
        DateTime bestBefore { get; set; }
        String seaStory { get; set; }
        String ingredients { get; set; }
    }
}
