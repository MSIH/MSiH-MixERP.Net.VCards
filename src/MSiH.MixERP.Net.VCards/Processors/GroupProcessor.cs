﻿using System.Linq;
using MSiH.MixERP.Net.VCards.Extensions;
using MSiH.MixERP.Net.VCards.Serializer;
using MSiH.MixERP.Net.VCards.Types;

namespace MSiH.MixERP.Net.VCards.Processors
{
    public static class GroupProcessor
    {
        public static string Serialize(string key, VCardVersion version, string type, bool mustEscape = false, params string[] members)
        {
            if (members == null || members.Count() == 0)
            {
                return string.Empty;
            }

            string value = string.Join(";", members.Select(x => mustEscape ? x.Escape() : x));
            return DefaultSerializer.GetVCardString(key, value, false, version, type);
        }
    }
}