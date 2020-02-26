using System.Threading.Tasks;
using Yandex.Entities;

namespace Yandex.Services.Contract
{
    /// <summary>
    /// Интерфейс сервиса получения времени от Яндекса
    /// </summary>
    public interface IYandexTimeService
    {
        /// <summary>
        /// Получить информацию о времени и погоде
        /// </summary>
        /// <param name="geoId">Идентификатор населенного пункта</param>
        Task<YandexClocks> GetYandexClocks(long geoId);
    }
}