using MSiH.MixERP.Net.VCards.Lookups;
using MSiH.MixERP.Net.VCards.Models;
using MSiH.MixERP.Net.VCards.Serializer;
using MSiH.MixERP.Net.VCards.Types;

namespace MSiH.MixERP.Net.VCards.Processors
{
    public static class GenderProcessor
    {
        public static string Serialize(VCard vcard)
        {
            //Only vCard 4.0 supports GENDER property
            if (vcard.Version != VCardVersion.V4)
            {
                return string.Empty;
            }

            return DefaultSerializer.GetVCardString("GENDER", vcard.Gender.ToVCardString(), true, vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            vcard.Gender = GenderLookup.Parse(token.Values[0]);
        }
    }
}