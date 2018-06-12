using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Interfaces;

namespace DAOLogic
{
    public class DAOMock : IDAO
    {
        private const int beerLength = 10;
        private List<IProducent> producents { get; set; }
        private List<IBeer> beers { get; set; }
        public DAOMock()
        {
            producents = new List<IProducent>();
            producents.Add(new Producent("Pinta", "Zawiercie", "Piwna", 50));
            beers = new List<IBeer>();
            for (int i = 0; i < beerLength; i++)
            {
                beers.Add(new Beer(Race.Bock, Speciality.Doppel, producents[0], 8, 25, 40, 15, 15, DateTime.Parse("01-01-2019"), "Behind the seven hills and seven rivers..", "water, barley malt: Pilzner malt, burned barley, hops: Magnum, bottom fermentation yeast"));
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

        public IBeer GetNewBeer()
        {
            return new Beer();
        }

        public void AddNewBeer( IBeer beer)
        {
            //adding beer to database
        //    beers.Add(beer);
        }

        public IProducent GetNewProducent()
        {
            return new Producent();
        }

        public void AddNewProducent(IProducent producent)
        {
            //adding producent to database
            //    producents.Add(producent);
        }
    }
}
