using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Yandex.Entities;
using Yandex.Services.Contract;

namespace Yandex.Services
{
    /// <summary>
    /// Сервис получения информации о времени и погоде в указанном населенном пункте
    /// </summary>
    public class YandexTimeService : IYandexTimeService
    {
        private string YandexTimeUrl = "https://yandex.ru/time/sync.json?geo={0}";

        /// <summary>
        /// Получение объекта JSON с информацией о времени и погоде
        /// </summary>
        /// <param name="geoId">Идентификатор населенного пункта в Яндексе</param>
        private async Task<JObject> GetTimeInfoJObject(long geoId)
        {
            JObject jsonResponse;
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(string.Format(YandexTimeUrl, geoId));
                var content = await response.Content.ReadAsStringAsync();
                jsonResponse = JObject.Parse(content);
            }

            return jsonResponse;
        }

        public async Task<YandexClocks> GetYandexClocks(long geoId)
        {
            var jsonResponse = await GetTimeInfoJObject(geoId);
            return YandexClocks.CreateFromJson(jsonResponse, geoId);
        }
    }
}