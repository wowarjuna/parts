using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;
using System.Collections;
using AutoPP.ApplicationServices.SerializableObjs;

namespace AutoPP.ApplicationServices
{
    public interface ISearchService
    {
        int TotalCount { get; }
        ICollection<KeyValuePair<string, List<string>>> Facets { get; }

        //IQueryable<Item> Search(Dictionary<string, object> parameters, int startIndex, int offset);

        SearchResults Search(Dictionary<string, object> parameters, int startIndex, int offset);
    }
}
