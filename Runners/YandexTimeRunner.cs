using System;
using System.Threading.Tasks;
using GetYandexTime.Contracts;

namespace GetYandexTime.Runners
{
    public class YandexTimeRunner
    {
        public async static Task Run(IYandexTimeService yandexTimeService, long geoId)
        {
            var model = await yandexTimeService.GetTimeInfo(geoId);
            Console.WriteLine(model.ToString());
        }
    }
}