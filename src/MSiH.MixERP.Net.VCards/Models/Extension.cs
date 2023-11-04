using System.Collections.Generic;
using System.Linq;
using MSiH.MixERP.Net.VCards.Extensions;

namespace MSiH.MixERP.Net.VCards.Models
{
    /// <summary>
    ///     Extended VCard Properties
    /// </summary>
    public sealed class CustomExtension
    {
        public string Key { get; set; }
        public IEnumerable<string> Values { get; set; }

        public string Value
        {
            set
            {
                var values = (Values?.ToList()).Coalesce(new List<string>());
                values.Add(value);
                Values = values;
            }
        }
    }
}