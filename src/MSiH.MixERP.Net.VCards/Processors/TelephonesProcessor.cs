﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSiH.MixERP.Net.VCards.Extensions;
using MSiH.MixERP.Net.VCards.Lookups;
using MSiH.MixERP.Net.VCards.Models;
using MSiH.MixERP.Net.VCards.Types;

namespace MSiH.MixERP.Net.VCards.Processors
{
    public static class TelephonesProcessor
    {
        public static string Serialize(VCard vcard)
        {
            if (vcard.Telephones == null || vcard.Telephones.Count() == 0)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();

            foreach (var phone in vcard.Telephones)
            {
                if (string.IsNullOrWhiteSpace(phone.Number))
                {
                    continue;
                }

                string type = phone.Type.ToVCardString(vcard.Version);

                string key = "TEL";

                if (vcard.Version == VCardVersion.V4)
                {
                    if (phone.Preference > 0)
                    {
                        key = key + ";PREF=" + phone.Preference;
                    }
                }

                builder.Append(GroupProcessor.Serialize(key, vcard.Version, type, true, phone.Number));
            }

            return builder.ToString();
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            if (string.IsNullOrWhiteSpace(token.Values[0]))
            {
                return;
            }

            var telephone = new Telephone();
            var preference = token.AdditionalKeyMembers.FirstOrDefault(x => x.Key == "PREF");
            var type = token.AdditionalKeyMembers.FirstOrDefault(x => x.Key == "TYPE");

            if (type.Key == null)
            {
                type = token.AdditionalKeyMembers.FirstOrDefault(x => x.Key != "PREF");
            }

            telephone.Preference = preference.Value.ConvertTo<int>();
            telephone.Type = TelephoneTypeLookup.Parse(type.Value != "" ? type.Value : type.Key);
            telephone.Number = token.Values[0];

            var telephones = (List<Telephone>)vcard.Telephones ?? new List<Telephone>();
            telephones.Add(telephone);
            vcard.Telephones = telephones;
        }
    }
}