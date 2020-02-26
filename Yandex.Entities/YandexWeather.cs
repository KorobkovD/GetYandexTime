using System;

namespace Yandex.Entities
{
    /// <summary>
    /// Информация о погоде для указанного населенного пункта
    /// </summary>
    public class YandexWeather
    {
        /// <summary>
        /// Температура
        /// </summary>
        public byte Temp { get; set; }

        /// <summary>
        /// Строковая ссылка на погоду
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Ссылка на погоду
        /// </summary>
        public Uri Uri => new Uri(Link);
    }
}