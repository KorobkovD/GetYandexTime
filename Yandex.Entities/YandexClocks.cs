using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Yandex.Entities
{
    /// <summary>
    /// Информация о времени в населенном пункте
    /// </summary>
    public class YandexClocks
    {
        /// <summary>
        /// Текущее время в миллисекундах
        /// </summary>
        public long Time { get; set; }

        /// <summary>
        /// Информация о погоде и населенном пункте
        /// </summary>
        public YandexTimeInfo TimeInfo { get; set; }

        /// <summary>
        /// Текущее время и дата
        /// </summary>
        public DateTime DateTime
        {
            get
            {
                var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                return start.AddMilliseconds(Time).ToLocalTime();
            }
        }

        /// <summary>
        /// Создание объекта из JObject
        /// </summary>
        public static YandexClocks CreateFromJson(JObject json, long geoId)
        {
            var yandexClocks = new YandexClocks();
            yandexClocks.Time = (long)json[YandexTimeResponseFieldNames.TimeParameterName];

            var dict = json[YandexTimeResponseFieldNames.ClocksParameterName]
                .ToObject<Dictionary<long, YandexTimeInfo>>();
            yandexClocks.TimeInfo = dict[geoId];

            return yandexClocks;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Текущая дата: {DateTime}, сейчас в {TimeInfo.Name} {(TimeInfo.IsNight ? "ночь" : "день")}");
            stringBuilder.AppendLine($"Временная зона: {TimeInfo.OffsetString}");
            stringBuilder.AppendLine($"Температура {TimeInfo.Weather.Temp} °C");
            stringBuilder.AppendLine($"Восход в {TimeInfo.Sunrise}, закат в {TimeInfo.Sunset}");

            return stringBuilder.ToString();
        }
    }
}