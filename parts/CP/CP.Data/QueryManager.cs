using CP.Data.DTO;
using System;
using System.Collections.Generic;
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
            using(var context = new CPDataContext())
            {
                var obj = context.Items.Single(x => x.Id.Equals(itemId));
                var returnObj = new DetailItemDTO { name = obj.Name, description = obj.Description, id = obj.Id };
                returnObj.images = (from x in obj.Images select new ItemImageDTO { name = x.OriginalName, url = x.Location }).ToList();
                returnObj.store = new StoreInfoDTO { address = obj.Store.Address };
                return returnObj;
            }
        }
    }
}