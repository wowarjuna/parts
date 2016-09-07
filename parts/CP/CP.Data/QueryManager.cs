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
                return context.Database.SqlQuery<SearchItemDTO>("sp_Search @category, @brand, @model",
                    new SqlParameter("@category", category),
                    new SqlParameter("@brand", brand),
                    new SqlParameter("@model", model)).ToList();
            }
        }
    }
}