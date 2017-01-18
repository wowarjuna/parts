using CP.Data.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data
{
    public static class QueryManager
    {
        public static IList<SearchItemDTO> Query(int category, int brand, string model, string text)
        {
            using (var context = new CPDataContext())
            {
                return context.Database.SqlQuery<SearchItemDTO>("sp_Search @category, @brand, @model, @text",
                    new SqlParameter("@category", category),
                    new SqlParameter("@brand", brand),
                    new SqlParameter("@model", model),
                    new SqlParameter("@text", text)).ToList();
            }
        }

        public static DetailItemDTO Get(long itemId)
        {
            DetailItemDTO item;
            using(var context = new CPDataContext())
            {
               
                item = context.Database.SqlQuery<DetailItemDTO>("sp_Get @partid", new SqlParameter("@partid", itemId)).First();
                item.images = context.Database.SqlQuery<ItemImageDTO>("sp_GetImages @partid", new SqlParameter("@partid", itemId)).ToList();
                return item;
            }
        }

        public static IList<KeyValuePair<int,string>> Categories()
        {
            using (var context = new CPDataContext())
            {
                return context.Database.SqlQuery<KeyValuePair<int,string>>("sp_Categories").ToList();
            }
        }
    }
}