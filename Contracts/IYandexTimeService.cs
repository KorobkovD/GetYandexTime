using System.Threading.Tasks;
using GetYandexTime.Models;

namespace GetYandexTime.Contracts
{
    /// <summary>
    /// Интерфейс сервиса получения времени от Яндекса
    /// </summary>
    public interface IYandexTimeService
    {
        /// <summary>
        /// Получить информацию о времени
        /// </summary>
        /// <param name="geoId">Идентификатор населенного пункта</param>
        Task<YandexTimeModel> GetTimeInfo(long geoId);
    }
}