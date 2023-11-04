using MSiH.MixERP.Net.VCards.Models;
using MSiH.MixERP.Net.VCards.Serializer;

namespace MSiH.MixERP.Net.VCards.Processors
{
    public static class UidProcessor
    {
        public static string Serialize(VCard vcard)
        {
            if (string.IsNullOrWhiteSpace(vcard.UniqueIdentifier))
            {
                return string.Empty;
            }

            return DefaultSerializer.GetVCardString("UID", vcard.UniqueIdentifier, true, vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            vcard.UniqueIdentifier = token.Values[0];
        }
    }
}