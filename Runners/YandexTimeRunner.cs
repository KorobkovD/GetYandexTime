using System;
using System.Threading.Tasks;
using Yandex.Services.Contract;

namespace GetYandexTime.Runners
{
    public class YandexTimeRunner
    {
        public static async Task Run(IYandexTimeService yandexTimeService, long geoId)
        {
            var model = await yandexTimeService.GetTimeInfo(geoId);
            Console.WriteLine(model.ToString());
        }
    }
}