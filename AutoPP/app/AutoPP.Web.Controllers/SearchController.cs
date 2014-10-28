using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using AutoPP.Web.Controllers.Util;
using SolrNet.Commands.Parameters;
using SolrNet;
using SolrNet.DSL;
using SolrNet.Exceptions;
using AutoPP.ApplicationServices;
using AutoPP.Core;
using AutoPP.ApplicationServices.SerializableObjs;

namespace AutoPP.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISolrReadOnlyOperations<VItem> solr;
        private readonly IItemsService _service;
        private readonly ISearchService _search;


        public SearchController(ISearchService search, ISolrReadOnlyOperations<VItem> solr, IItemsService service)
        {
            this.solr = solr;
            this._service = service;
            this._search = search;
        }

        /// <summary>
        /// Builds the Solr query from the search parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public ISolrQuery BuildQuery(SearchParameters parameters)
        {
            if (!string.IsNullOrEmpty(parameters.FreeSearch))
                return new SolrQuery(parameters.FreeSearch);
            return SolrQuery.All;
        }

        public ICollection<ISolrQuery> BuildFilterQueries(SearchParameters parameters)
        {
            var queriesFromFacets = from p in parameters.Facets
                                    select (ISolrQuery)Query.Field(p.Key).Is(p.Value);
            return queriesFromFacets.ToList();
        }

        public SortOrder[] GetSelectedSort(SearchParameters parameters)
        {
            return new[] { SortOrder.Parse(parameters.Sort) }.Where(o => o != null).ToArray();
        }

        /// <summary>
        /// All selectable facet fields
        /// </summary>
        private static readonly string[] AllFacetFields = new[] { "cat", "model", "city" };

        /// <summary>
        /// Gets the selected facet fields
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IEnumerable<string> SelectedFacetFields(SearchParameters parameters)
        {
            return parameters.Facets.Select(f => f.Key);
        }

        public ActionResult Index(SearchParameters parameters)
        {
            try
            {
                var view = new ItemView();                    
                var start = (parameters.PageIndex - 1) * parameters.PageSize;
                    
                /*
                    var matchingProducts = solr.Query(BuildQuery(parameters), new QueryOptions
                    {
                        FilterQueries = BuildFilterQueries(parameters),
                        Rows = parameters.PageSize,
                        Start = start,
                        OrderBy = GetSelectedSort(parameters),
                        SpellCheck = new SpellCheckingParameters(),
                        Facet = new FacetParameters
                        {
                            Queries = AllFacetFields.Except(SelectedFacetFields(parameters))
                                                                                  .Select(f => new SolrFacetFieldQuery(f) { MinCount = 1 })
                                                                                  .Cast<ISolrFacetQuery>()
                                                                                  .ToList(),
                        },
                    });
                    view = new ItemView
                    {
                        Items = matchingProducts,
                        Search = parameters,
                        TotalCount = matchingProducts.NumFound,
                        Facets = matchingProducts.FacetFields,
                        DidYouMean = GetSpellCheckingResult(matchingProducts),
                    };*/

                    
                    if (parameters.FreeSearch != null)
                    {
                        var _params = new Dictionary<string, object>();
                        _params.Add("keyword", parameters.FreeSearch);

                        // IQueryable<Item> _query = _search.Search(_params, start, parameters.PageSize);
                        SearchResults _result = _search.Search(_params, start, parameters.PageSize);
                        view = new ItemView
                        {
                            /*Items = (from _i in _result.Results
                                     select new VItem
                                     {
                                         Name = _i.Name,
                                         Description = _i.Description,
                                         Year = (_i.Year != null ? int.Parse(_i.Year) : 0),
                                         Gallery = _i.Galleries.Count != 0 ? _i.Galleries.First().GalleryId.ToString() : string.Empty,
                                         Resource = _i.Galleries.Count != 0 ? _i.Galleries.First().PrimaryResource : string.Empty,
                                         Id = _i.Id.ToString()
                                     }).ToList(),*/
                            Items = (from _i in _result.Results
                                     select new VItem
                                     {
                                         Name = _i.Name,
                                         Description = _i.Description,
                                         Year = (_i.Year != null ? _i.Year : 0),
                                         Id = _i.Id.ToString()
                                     }).ToList(),
                            TotalCount = _result.Total,
                            Search = parameters,
                            Facets = _result.Taxonomies
                        };
                    }
                
                return View(view);
                
                
            }
            catch (InvalidFieldException)
            {
                return View(new ItemView
                {
                    QueryError = true,
                });
            }
           
        }

        private string GetSpellCheckingResult(ISolrQueryResults<VItem> products)
        {
            return string.Join(" ", products.SpellChecking
                                        .Select(c => c.Suggestions.FirstOrDefault())
                                        .Where(c => !string.IsNullOrEmpty(c))
                                        .ToArray());
        }

        public ActionResult Detail(int Id)
        {
            var _item = _service.Get(Id);
            _item.NoOfHits = _item.NoOfHits != null ? _item.NoOfHits + 1 : 1;
            RecordHitUpdate _delegate = UpdateRecordHits;
            _delegate(_item, _service);
            
            return View(_item);
        }

        delegate void RecordHitUpdate(Item item, IItemsService service);

        private void UpdateRecordHits(Item item, IItemsService service)
        {
            service.Update(item);
        }
    }
}
