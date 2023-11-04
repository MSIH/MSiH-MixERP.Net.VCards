using System;
using System.Globalization;
using MSiH.MixERP.Net.VCards.Serializer;
using MSiH.MixERP.Net.VCards.Types;

namespace MSiH.MixERP.Net.VCards.Processors
{
    public static class DateTimeProcessor
    {
        public static string Serialize(DateTime? value, string key, VCardVersion version)
        {
            string serializedValue = value?.ToString("o") ?? string.Empty;

            return string.IsNullOrWhiteSpace(serializedValue) ? string.Empty : DefaultSerializer.GetVCardString(key, serializedValue, false, version);
        }

        public static DateTime? Parse(string value)
        {
            DateTime parsed;

            if (DateTime.TryParseExact(value, new[] {"o", "s", "yyyy-MM-ddTHH:mm:ssZ", "yyyy-MM-dd"}, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out parsed))
            {
                return parsed;
            }

            return null;
        }
    }
}