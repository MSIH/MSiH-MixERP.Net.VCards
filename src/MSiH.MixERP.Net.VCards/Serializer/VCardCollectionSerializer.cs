﻿using MSiH.MixERP.Net.VCards;
using System.Collections.Generic;
using System.Text;

namespace MSiH.MixERP.Net.VCards.Serializer
{
    public static class VCardCollectionSerializer
    {
        public static string Serialize(this IEnumerable<VCard> vcards)
        {
            var builder = new StringBuilder();
            foreach (var vcard in vcards)
            {
                builder.Append(vcard.Serialize());
            }

            return builder.ToString();
        }
    }
}