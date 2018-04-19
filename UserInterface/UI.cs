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
                Console.WriteLine($"Producent's name: {producent.name}\nTown: {producent.town}\nStreet: {producent.street}\nStreet number: {producent.streetNumber}");
                Console.WriteLine($"-------------------");
            }
        }
        private static void printAllBeers( List<IBeer> beers)
        {   
            for (int i = 0; i < beers.Count; i++)
            {
                IBeer beer = beers[i];
                Console.WriteLine($"Bear number {i + 1}:");
                Console.WriteLine($"{beer.speciality} {beer.race}\nProducent: {beer.producent.name}\n{beer.alcoholPercent}% of alcohol\nDensity of wort (BLG): {beer.BLG}\nBiterness in IBU scale: {beer.IBU}\nHue in EBC scale: {beer.EBC}\nBest drink in temperature: {beer.servingTemperature}C and to: {beer.bestBefore}\nSea story: {beer.seaStory}\nIngredients: {beer.ingredients}");
                Console.WriteLine($"Cheers!");
                Console.WriteLine($"-------------------");
            }
        }

        public static void Main(string[] args)
        {
            IBL _bl = new BL();
            printAllBeers(_bl.getData().getBeers());
            printAllProducents(_bl.getData().getProducents());
            Console.ReadLine();
        }
    }
}
