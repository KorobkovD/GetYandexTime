using System;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Yandex.Entities.Models
{
    /// <summary>
    /// Модель для представления данных от сервиса Yandex Time
    /// </summary>
    public class YandexTimeModel
    {
        /// <summary>
        /// Текущие дата и время
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Идентификатор поселения в Яндекс
        /// </summary>
        public long SettlementId { get; set; }

        /// <summary>
        /// Название поселения
        /// </summary>
        public string SettlementName { get; set; }

        /// <summary>
        /// Смещение времени в миллисекундах
        /// </summary>
        public long OffsetMilliseconds { get; set; }

        /// <summary>
        /// Смещение времени строкой
        /// </summary>
        public string OffsetString { get; set; }

        /// <summary>
        /// Информация о восходе солнца
        /// </summary>
        public string SunriseInfo { get; set; }

        /// <summary>
        /// Информация о закате солнца
        /// </summary>
        public string SunsetInfo { get; set; }

        /// <summary>
        /// Признак темного времени суток
        /// </summary>
        public bool IsNight { get; set; }

        /// <summary>
        /// Значение температуры
        /// </summary>
        public byte Temperature { get; set; }

        /// <summary>
        /// Ссылка на погоду
        /// </summary>
        public Uri YandexWeatherUri { get; set; }

        public static YandexTimeModel CreateFromJson(JObject json, long geoId)
        {
            var geoIdString = geoId.ToString();

            var dateTimeLong = (long)json[YandexTimeResponseFieldNames.TimeParameterName];
            var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var dateTime = start.AddMilliseconds(dateTimeLong).ToLocalTime();
            var settlementId = (long)json
                    [YandexTimeResponseFieldNames.ClocksParameterName]
                    [geoIdString]
                    [YandexTimeResponseFieldNames.SettlementIdParameterName];
            var settlementName = (string)json
                    [YandexTimeResponseFieldNames.ClocksParameterName]
                    [geoIdString]
                    [YandexTimeResponseFieldNames.SettlementParameterName];
            var offsetMilliseconds = (long)json
                    [YandexTimeResponseFieldNames.ClocksParameterName]
                    [geoIdString]
                    [YandexTimeResponseFieldNames.OffsetParameterName];
            var offsetString = (string)json
                    [YandexTimeResponseFieldNames.ClocksParameterName]
                    [geoIdString]
                    [YandexTimeResponseFieldNames.OffsetStringParameterName];
            var sunriseInfo = (string)json
                    [YandexTimeResponseFieldNames.ClocksParameterName]
                    [geoIdString]
                    [YandexTimeResponseFieldNames.SunriseParameterName];
            var sunsetInfo = (string)json
                    [YandexTimeResponseFieldNames.ClocksParameterName]
                    [geoIdString]
                    [YandexTimeResponseFieldNames.SunsetParameterName];
            var isNight = (bool)json
                    [YandexTimeResponseFieldNames.ClocksParameterName]
                    [geoIdString]
                    [YandexTimeResponseFieldNames.IsNightParameterName];
            var temperature = (byte)json
                    [YandexTimeResponseFieldNames.ClocksParameterName]
                    [geoIdString]
                    [YandexTimeResponseFieldNames.WeatherParameterName]
                    [YandexTimeResponseFieldNames.TemperatureParameterName];
            var yandexWeatherUri = new Uri((string)json
                    [YandexTimeResponseFieldNames.ClocksParameterName]
                    [geoIdString]
                    [YandexTimeResponseFieldNames.WeatherParameterName]
                    [YandexTimeResponseFieldNames.WeatherLinkParameterName]);

            return new YandexTimeModel
            {
                DateTime = dateTime,
                SettlementId = settlementId,
                SettlementName = settlementName,
                OffsetMilliseconds = offsetMilliseconds,
                OffsetString = offsetString,
                SunriseInfo = sunriseInfo,
                SunsetInfo = sunsetInfo,
                IsNight = isNight,
                Temperature = temperature,
                YandexWeatherUri = yandexWeatherUri
            };
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Текущая дата: {DateTime}, сейчас в {SettlementName} {(IsNight ? "ночь" : "день")}");
            stringBuilder.AppendLine($"Временная зона: {OffsetString}");
            stringBuilder.AppendLine($"Температура {Temperature} °C");
            stringBuilder.AppendLine($"Восход в {SunriseInfo}, закат в {SunsetInfo}");

            return stringBuilder.ToString();
        }
    }
}