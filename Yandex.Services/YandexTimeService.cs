using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Yandex.Entities.Models;
using Yandex.Services.Contract;

namespace Yandex.Services
{
    public class YandexTimeService : IYandexTimeService
    {
        private string YandexTimeUrl = "https://yandex.ru/time/sync.json?geo={0}";

        public async Task<YandexTimeModel> GetTimeInfo(long geoId)
        {
            JObject jsonResponse;
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(string.Format(YandexTimeUrl, geoId));
                var content = await response.Content.ReadAsStringAsync();
                jsonResponse = JObject.Parse(content);
            }

            return YandexTimeModel.CreateFromJson(jsonResponse, geoId);
        }
    }
}