using MSiH.MixERP.Net.VCards.Lookups;
using MSiH.MixERP.Net.VCards.Models;
using MSiH.MixERP.Net.VCards.Serializer;
using MSiH.MixERP.Net.VCards.Types;

namespace MSiH.MixERP.Net.VCards.Processors
{
    public static class ClassificationProcessor
    {
        public static string Serialize(VCard vcard)
        {
            //The property "CLASS" is valid only for VCardVersion 3.0 and above.
            if (vcard.Version == VCardVersion.V2_1)
            {
                return string.Empty;
            }

            string classification = ClassificationLookup.ToVCardString(vcard.Classification);
            return DefaultSerializer.GetVCardString("CLASS", classification, true, vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            vcard.Classification = ClassificationLookup.Parse(token.Values[0]);
        }
    }
}