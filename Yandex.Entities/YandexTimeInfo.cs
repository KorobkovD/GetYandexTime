namespace Yandex.Entities
{
    /// <summary>
    /// Информация о погоде и населенном пункте
    /// </summary>
    public class YandexTimeInfo
    {
        /// <summary>
        /// Идентификатор населенного пункта
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название НП
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Смещение таймзоны в миллисекундах
        /// </summary>
        public long Offset { get; set; }

        /// <summary>
        /// Часовой пояс
        /// </summary>
        public string OffsetString { get; set; }

        /// <summary>
        /// Время восхода
        /// </summary>
        public string Sunrise { get; set; }

        /// <summary>
        /// Время заката
        /// </summary>
        public string Sunset { get; set; }

        /// <summary>
        /// Признак темного времени суток
        /// </summary>
        public bool IsNight { get; set; }

        /// <summary>
        /// Информация о погоде
        /// </summary>
        public YandexWeather Weather { get; set; }
    }
}