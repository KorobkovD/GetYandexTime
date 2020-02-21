using System.Threading.Tasks;
using GetYandexTime.Models;

namespace GetYandexTime.Contracts
{
    public interface IYandexTimeService
    {
        Task<YandexTimeModel> GetTimeInfo(long geoId);
    }
}