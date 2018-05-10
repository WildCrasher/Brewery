using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Interfaces;

namespace DAOLogic
{
    public class DAOMock2 : IDAO
    {
        private const int beerLength = 5;
        private List<IProducent> producents { get; set; }
        private List<IBeer> beers { get; set; }
        public DAOMock2()
        {
            producents = new List<IProducent>();
            producents.Add(new Producent("Golem", "Poznań", "Polanka", 18));
            beers = new List<IBeer>();
            for (int i = 0; i < beerLength; i++)
            {
                beers.Add(new Beer(Race.Stout, Speciality.Whisky | Speciality.Extra, producents[0], 7.5, 20, 70, 15, 18, DateTime.Parse("02-10-2020"), "Behind the seven hills and seven rivers..", "water, barley malt: Pilzner malt, burned rye, whisky malt hops: Magnum, up fermentation yeast"));
            }
        }

        public List<IBeer> getBeers()
        {
            return beers;
        }

        public List<IProducent> getProducents()
        {
            return producents;
        }
    }
}
