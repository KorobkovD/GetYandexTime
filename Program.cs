using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetYandexTime
{
    internal class Program
    {
        private static byte GeoId = 35;
        private static string YandexTimeService = "https://yandex.ru/time/sync.json?geo={0}";

        private static async Task Main(string[] args)
        {
            long dateTimeLong;
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(string.Format(YandexTimeService, GeoId));
                var content = await response.Content.ReadAsStringAsync();
                var j = JObject.Parse(content);
                dateTimeLong = (long)j["time"];
            }

            var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var date = start.AddMilliseconds(dateTimeLong).ToLocalTime();

            Console.WriteLine(date.ToString("f"));
            Console.ReadKey();
        }
    }
}