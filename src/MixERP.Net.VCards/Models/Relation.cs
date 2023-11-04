using System;
using MSiH.MixERP.Net.VCards.Types;

namespace MSiH.MixERP.Net.VCards.Models
{
    public sealed class Relation
    {
        public RelationType Type { get; set; }
        public int Preference { get; set; }
        public Uri RelationUri { get; set; }
    }
}