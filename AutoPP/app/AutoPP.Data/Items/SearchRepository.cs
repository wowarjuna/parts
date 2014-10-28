using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPP.Core.RepositoryInterfaces;
using AutoPP.Core;
using SharpArch.Data.NHibernate;


namespace AutoPP.Data.Items
{
    public class SearchRepository : Repository<SearchItem>, ISearchRepository
    {
        public IQueryable<SearchItem> GetItems(IDictionary<string, object> parameters, int startIndex, int offset, out int Count)
        {
            Count = 10;
//            Count = int.Parse(Session.CreateSQLQuery(string.Format(@"SELECT count(FT_TBL.Id)
//                                FROM VItemSearch AS FT_TBL INNER JOIN
//                                CONTAINSTABLE (VItemSearch, (Meta), '{0}') AS KEY_TBL
//                                ON FT_TBL.Id = KEY_TBL.[KEY]", string.Join(" AND ", parameters["keyword"].ToString().Split(new char[] { ' ' })))).UniqueResult().ToString());
//            var _result = Session.CreateSQLQuery(string.Format(@"SELECT FT_TBL.Id,FT_TBL.ItemName, FT_TBL.ItemDescription, FT_TBL.YearOfManu,
//                                FT_TBL.Model, FT_TBL.City, FT_TBL.GalleryId, FT_TBL.Image  
//                                FROM VItemSearch AS FT_TBL INNER JOIN
//                                CONTAINSTABLE (VItemSearch, (Meta), '{0}') AS KEY_TBL
//                                ON FT_TBL.Id = KEY_TBL.[KEY]
//                                order by RANK desc", string.Join(" AND ", parameters["keyword"].ToString().Split(new char[] { ' ' }))))
//                                                   .SetFirstResult(startIndex).SetMaxResults(offset).List<object[]>();
            var _result = Session.CreateSQLQuery(string.Format(@"SELECT FT_TBL.Id,FT_TBL.ItemName, FT_TBL.ItemDescription, FT_TBL.YearOfManu,
                                FT_TBL.Model, FT_TBL.City, FT_TBL.GalleryId, FT_TBL.Image  
                                FROM item_search")).SetFirstResult(startIndex).SetMaxResults(offset).List<object[]>();
            return (from _i in _result
                    select new SearchItem
                    {
                        Id = _i[0].ToString(),
                        Name = _i[1].ToString(),
                        Description = _i[2].ToString()
                        
                    }).AsQueryable();
            
        }

       
       
    }
}
