using MSiH.MixERP.Net.VCards;
using MSiH.MixERP.Net.VCards.Models;
using MSiH.MixERP.Net.VCards.Serializer;

namespace MSiH.MixERP.Net.VCards.Processors
{
    public static class NoteProcessor
    {
        public static string Serialize(VCard vcard)
        {
            if (string.IsNullOrWhiteSpace(vcard.Note))
            {
                return string.Empty;
            }

            return DefaultSerializer.GetVCardString("NOTE", vcard.Note, true, vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            vcard.Note = token.Values[0];
        }
    }
}