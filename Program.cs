using GetYandexTime.Runners;
using GetYandexTime.Services;
using System;
using System.Threading.Tasks;

namespace GetYandexTime
{
    internal class Program
    {
        //private static long GeoId = 35;

        private static async Task Main(string[] args)
        {
            //await YandexTimeRunner.Run(new YandexTimeService(), GeoId);

            if (!long.TryParse(args[0], out var geoId))
            {
                Console.WriteLine("Идентификатор региона указан в некорректном формате");
            }
            else
            {
                await YandexTimeRunner.Run(new YandexTimeService(), geoId);
            }
            Console.ReadKey();
        }
    }
}