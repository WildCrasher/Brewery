using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace DAOLogic
{
    public class DAOMock : Interfaces.IDAO
    {
        private const int length = 10;
        public DataObject[] beers { get; set; }
        public DAOMock()
        {
            beers = new DataObject[length];
            for (int i = 0; i < length; i++)
            {
                beers[i] = new DataObject( Race.Bock, Speciality.Doppel, 8, 25, 40, 15, 15, DateTime.Parse("01-01-2019"), "Behind the seven hills and seven rivers..", "water, barley malt: Pilzner malt, burned barley, hops: Magnum, bottom fermentation yeast" );
            }
        }

        public void print()
        {
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Bear number {i + 1}:");
                Console.WriteLine($"{beers[i].speciality} {beers[i].race}\n{beers[i].alcoholPercent}% of alcohol\nDensity of wort (BLG): {beers[i].BLG}\nBiterness in IBU scale: {beers[i].IBU}\nHue in EBC scale: {beers[i].EBC}\nBest drink in temperature: {beers[i].servingTemperature}C and to: {beers[i].bestBefore}\nSea story: {beers[i].seaStory}\nIngredients: {beers[i].ingredients}");
                Console.WriteLine("Cheers!");
                Console.WriteLine("-------------------");
            }
        }
    }
}
