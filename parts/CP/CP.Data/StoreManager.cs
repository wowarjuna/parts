using CP.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data
{
    public static class StoreManager
    {
        public static IList<StoreItemDTO> List()
        {
            using (var context = new CPDataContext())
            {
                return context.Database.SqlQuery<StoreItemDTO>("sp_Stores").ToList();
            }
        }
    }
}
