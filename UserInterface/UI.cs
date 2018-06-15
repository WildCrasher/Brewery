using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using BusinessLogic;

namespace UserInterface
{
    public class UI
    {
        private static void printAllProducents(List<IProducent> producents)
        {
            for (int i = 0; i < producents.Count; i++)
            {
                IProducent producent = producents[i];
                Console.WriteLine($"Producent number {i + 1}:");
                Console.WriteLine($"Producent's name: {producent.Name}\nTown: {producent.Town}\nStreet: {producent.Street}\nStreet number: {producent.StreetNumber}");
                Console.WriteLine($"-------------------");
            }
        }

        private static void printAllBeers( List<IBeer> beers)
        {   
            for (int i = 0; i < beers.Count; i++)
            {
                IBeer beer = beers[i];
                Console.WriteLine($"Bear number {i + 1}:");
                Console.WriteLine($"{beer.Speciality} {beer.Race}\nProducent: {beer.Producent.Name}\n{beer.AlcoholPercent}% of alcohol\nDensity of wort (BLG): {beer.BLG}\nBiterness in IBU scale: {beer.IBU}\nHue in EBC scale: {beer.EBC}\nBest drink in temperature: {beer.ServingTemperature}C and to: {beer.BestBefore}\nSea story: {beer.SeaStory}\nIngredients: {beer.Ingredients}");
                Console.WriteLine($"Cheers!");
                Console.WriteLine($"-------------------");
            }
        }

        public static void Main(string[] args)
        {
            IBL _bl = new BL();
            printAllBeers(_bl.GetData().GetBeers());
            printAllProducents(_bl.GetData().GetProducents());
            Console.ReadLine();
        }
    }
}
