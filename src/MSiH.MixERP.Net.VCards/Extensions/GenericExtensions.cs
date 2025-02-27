using System;

namespace MSiH.MixERP.Net.VCards.Extensions
{
    public static class GenericExtensions
    {
        public static T ConvertTo<T>(this string valueAsString) where T : struct
        {
            if (string.IsNullOrEmpty(valueAsString))
            {
                return default;
            }

            return (T)Convert.ChangeType(valueAsString, typeof(T));
        }

        public static T? ConvertToNullableT<T>(this string valueAsString) where T : struct
        {
            if (string.IsNullOrEmpty(valueAsString))
            {
                return null;
            }

            return (T)Convert.ChangeType(valueAsString, typeof(T));
        }

        public static string Coalesce(this string actual, string substitute)
        {
            if (string.IsNullOrWhiteSpace(actual))
            {
                return substitute;
            }

            return actual;
        }

        public static T Coalesce<T>(this T actual, T substitute)
        {
            if (actual == null)
            {
                return substitute;
            }

            return actual;
        }
    }
}