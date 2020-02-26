using GetYandexTime.Runners;
using System;
using System.Threading.Tasks;
using Yandex.Services;

namespace GetYandexTime
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
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