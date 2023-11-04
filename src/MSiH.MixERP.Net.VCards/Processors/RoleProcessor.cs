using MSiH.MixERP.Net.VCards.Models;
using MSiH.MixERP.Net.VCards.Serializer;

namespace MSiH.MixERP.Net.VCards.Processors
{
    public static class RoleProcessor
    {
        public static string Serialize(VCard vcard)
        {
            if (string.IsNullOrWhiteSpace(vcard.Role))
            {
                return string.Empty;
            }

            return DefaultSerializer.GetVCardString("ROLE", vcard.Role, true, vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            vcard.Role = token.Values[0];
        }
    }
}