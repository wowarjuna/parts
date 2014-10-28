using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoPP.Web.Controllers.Helpers
{
    public static class EnumerableExtensions
    {
        public static IDictionary<K, V> ToDictionary<K, V>(this IEnumerable<KeyValuePair<K, V>> list)
        {
            return list.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}
