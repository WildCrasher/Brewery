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
        private const int BeerLength = 5;
        private List<IProducent> Producents { get; set; }
        private List<IBeer> Beers { get; set; }
        public DAOMock2()
        {
            Producents = new List<IProducent>();
            Producents.Add(new Producent("Golem", "Poznań", "Polanka", 18));
            Beers = new List<IBeer>();
            for (int i = 0; i < BeerLength; i++)
            {
                Beers.Add(new Beer(Race.Stout, Speciality.Whisky | Speciality.Extra, Producents[0], 7.5, 20, 70, 15, 18, DateTime.Parse("02-10-2020"), "Behind the seven hills and seven rivers..", "water, barley malt: Pilzner malt, burned rye, whisky malt hops: Magnum, up fermentation yeast"));
            }
        }

        public List<IBeer> GetBeers()
        {
            return Beers;
        }

        public IBeer GetNewBeer()
        {
            return new Beer();
        }

        public void AddNewBeer(IBeer beer)
        {
            Beers.Add(beer);
        }

        public void EditBeer(IBeer beer, int index)
        {
            Beers[index].Race = beer.Race;
            Beers[index].Speciality = beer.Speciality;
            Beers[index].Producent = beer.Producent;
            Beers[index].AlcoholPercent = beer.AlcoholPercent;
            Beers[index].IBU = beer.IBU;
            Beers[index].EBC = beer.EBC;
            Beers[index].ServingTemperature = beer.ServingTemperature;
            Beers[index].BLG = beer.BLG;
            Beers[index].BestBefore = beer.BestBefore;
            Beers[index].SeaStory = beer.SeaStory;
            Beers[index].Ingredients = beer.Ingredients;
        }

        public void RemoveBeer(int selectedIndex)
        {
            if (selectedIndex >= 0 && selectedIndex < Beers.Count)
            {
                Beers.RemoveAt(selectedIndex);
            }
        }

        public List<IProducent> GetProducents()
        {
            return Producents;
        }

        public IProducent GetNewProducent()
        {
            return new Producent();
        }

        public void AddNewProducent(IProducent producent)
        {
            Producents.Add(producent);
        }

        public void EditProducent(IProducent producent, int index)
        {
            Producents[index].Name = producent.Name;
            Producents[index].Town = producent.Town;
            Producents[index].Street = producent.Street;
            Producents[index].StreetNumber = producent.StreetNumber;
        }

        public void RemoveProducent(int selectedIndex)
        {
            if (selectedIndex >= 0 && selectedIndex < Producents.Count)
            {
                Producents.RemoveAt(selectedIndex);
            }
        }
    }
}
