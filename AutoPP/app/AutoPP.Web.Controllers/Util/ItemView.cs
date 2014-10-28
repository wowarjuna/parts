using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;

namespace AutoPP.Web.Controllers.Util
{
    public class ItemView
    {
        public SearchParameters Search { get; set; }
        public ICollection<VItem> Items { get; set; }
        public int TotalCount { get; set; }
        public IDictionary<string, ICollection<KeyValuePair<string, int>>> Facets { get; set; }
        public string DidYouMean { get; set; }
        public bool QueryError { get; set; }

        public ItemView()
        {
            Search = new SearchParameters();
            Facets = new Dictionary<string, ICollection<KeyValuePair<string, int>>>();
            Items = new List<VItem>();
        }
    }
}
