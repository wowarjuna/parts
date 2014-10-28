using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;

namespace AutoPP.ApplicationServices.SerializableObjs
{
    public class SearchResults
    {
        public IQueryable<SearchItem> Results { get; set; }
        public IDictionary<string, ICollection<KeyValuePair<string, int>>> Taxonomies { get; set; }
        public int Total { get; set; }
    }
}
