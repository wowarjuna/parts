using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core;
using AutoPP.Core.RepositoryInterfaces;
using AutoPP.ApplicationServices.SerializableObjs;
using System.Globalization;

namespace AutoPP.ApplicationServices.Impl
{
    public class MSSQLSearchService : ISearchService
    {
        private int _total;

        private ICollection<KeyValuePair<string, List<string>>> _facets;

        public int TotalCount { get { return _total; } }

        public ICollection<KeyValuePair<string, List<string>>> Facets { get { return _facets; } }

        ISearchRepository _repository;

        public MSSQLSearchService(ISearchRepository repository)
        {
            _repository = repository;
        }
               
        /*
        public IQueryable<Item> Search(Dictionary<string, object> parameters, int startIndex, int offset)
        {
            if (parameters["keyword"] != null)
                return _repository.GetItems(f => (f.Description.IndexOf(parameters["keyword"].ToString(), StringComparison.OrdinalIgnoreCase) != -1) || 
                    (f.Name.IndexOf(parameters["keyword"].ToString(), StringComparison.OrdinalIgnoreCase) != -1), startIndex, offset, out _total);
            else
                return _repository.GetItems(f => true, startIndex, offset, out _total);
        }
        */

        public SearchResults Search(Dictionary<string, object> parameters, int startIndex, int offset)
        {
            
            var _result = new SearchResults();
            int _total = 0;
            _result.Results = _repository.GetItems(parameters, startIndex, offset, out _total);
            _result.Total = _total;
            
            /*
            var _keywords = KeywordsVariants(parameters["keyword"].ToString());
            var _query = _repository.GetItems().Where(f => f.Description.IndexOf(parameters["keyword"].ToString(), StringComparison.OrdinalIgnoreCase) != -1 ||
                    f.Name.IndexOf(parameters["keyword"].ToString(), StringComparison.OrdinalIgnoreCase) != -1);
            
            _result.Total = _query.Count<Item>();
            _result.Results = _query.OrderByDescending(x => x.ModifiedOn).Skip(startIndex).Take(offset).AsQueryable();
            IDictionary<string, ICollection<KeyValuePair<string, int>>> _taxos = new Dictionary<string, ICollection<KeyValuePair<string, int>>>();
            var _cities = from item in _query
                          group item by item.Vendor.City
                              into cities
                              select new KeyValuePair<string, int>(cities.Key, cities.Count());
            _taxos.Add("Cities", _cities.ToList());*/
                            
            return _result;
        }

        private List<string> KeywordsVariants(string keyword)
        {
            TextInfo myTI = new CultureInfo("en-US",false).TextInfo;
            List<string> _results = new List<string>();
            var _words = keyword.Split(new char[] { ' ' });
            foreach(var _word in _words)
            {
                _results.Add(myTI.ToLower(_word));
                _results.Add(myTI.ToUpper(_word));
                _results.Add(myTI.ToTitleCase(_word));
            }

            return _results;
        }
    }
}
