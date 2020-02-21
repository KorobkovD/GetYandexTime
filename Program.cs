using GetYandexTime.Runners;
using GetYandexTime.Services;
using System;
using System.Threading.Tasks;

namespace GetYandexTime
{
    internal class Program
    {
        private static byte GeoId = 35;

        private static async Task Main(string[] args)
        {
            await YandexTimeRunner.Run(new YandexTimeService(), GeoId);
            Console.ReadKey();
        }
    }
}