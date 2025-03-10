﻿using System.Text.RegularExpressions;

namespace MSiH.MixERP.Net.VCards.Helpers
{
    public static class VCardHelper
    {
        public static string[] SplitCards(string contents)
        {
            //  return Regex.Split(contents, "((BEGIN:VCARD)(.*)(END:VCARD))");

            string[] vcardEntries = Regex.Split(contents, @"(?<=END:VCARD)\s*\n*");
            return vcardEntries;
        }
    }
}